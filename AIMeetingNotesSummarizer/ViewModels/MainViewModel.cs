using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AIMeetingNotesSummarizer.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;


namespace AIMeetingNotesSummarizer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly Services.ITranscriptionService _transcription;
        private readonly Services.ISummarizationService _summarizer;
        private readonly Services.IPersistenceService _persistence;


        public MainViewModel(Services.ITranscriptionService transcription,
        Services.ISummarizationService summarizer,
        Services.IPersistenceService persistence)
        {
            _transcription = transcription;
            _summarizer = summarizer;
            _persistence = persistence;


            Meetings = new ObservableCollection<Meeting>(_persistence.LoadAllMeetings());
            SelectedMeeting = Meetings.FirstOrDefault() ?? new Meeting { Title = "New Meeting" };
        }


        [ObservableProperty]
        private ObservableCollection<Meeting> meetings;


        [ObservableProperty]
        private Meeting selectedMeeting;


        [ObservableProperty]
        private bool isBusy;


        [RelayCommand]
        public async Task ImportAudioAsync()
        {
            IsBusy = true;
            try
            {
                // Stub import - in real app use OpenFileDialog and call transcription service
                var meeting = await _transcription.TranscribeFileAsync("sample-audio.wav");
                Meetings.Add(meeting);
                SelectedMeeting = meeting;
            }
            finally { IsBusy = false; }
        }


        [RelayCommand]
        public async Task SummarizeSelectedAsync()
        {
            if (SelectedMeeting == null) return;
            IsBusy = true;
            try
            {
                var summary = await _summarizer.SummarizeAsync(SelectedMeeting.Transcript);
                SelectedMeeting.Summary = summary;
                _persistence.SaveMeeting(SelectedMeeting);
                OnPropertyChanged(nameof(SelectedMeeting));
            }
            finally { IsBusy = false; }
        }


        [RelayCommand]
        public void SaveMeeting()
        {
            if (SelectedMeeting != null)
                _persistence.SaveMeeting(SelectedMeeting);
        }
    }
}