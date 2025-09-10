using AIMeetingNotesSummarizer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace AIMeetingNotesSummarizer.Services
{
    public class FilePersistenceService : IPersistenceService
    {
        private readonly string _folder;
        public FilePersistenceService()
        {
            _folder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "AiMeetingNotes");
            Directory.CreateDirectory(_folder);
        }


        public IEnumerable<Meeting> LoadAllMeetings()
        {
            var files = Directory.GetFiles(_folder, "*.json");
            return files.Select(f => JsonConvert.DeserializeObject<Meeting>(File.ReadAllText(f))).Where(m => m != null)!.Cast<Meeting>();
        }


        public void SaveMeeting(Meeting meeting)
        {
            var path = Path.Combine(_folder, meeting.Id + ".json");
            File.WriteAllText(path, JsonConvert.SerializeObject(meeting, Newtonsoft.Json.Formatting.Indented));
        }
    }
}