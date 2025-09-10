using AIMeetingNotesSummarizer.Models;
using System.Threading.Tasks;
using System;

namespace AIMeetingNotesSummarizer.Services
{
    public class StubTranscriptionService : ITranscriptionService
    {
        public Task<Meeting> TranscribeFileAsync(string filePath)
        {
            var mt = new Meeting { Title = System.IO.Path.GetFileNameWithoutExtension(filePath), Date = DateTime.UtcNow };
            mt.Transcript.Add(new TranscriptSegment { Start = TimeSpan.Zero, End = TimeSpan.FromSeconds(8), Speaker = "Alice", Text = "Welcome everyone to the sync. Today we will discuss the release plan." });
            mt.Transcript.Add(new TranscriptSegment { Start = TimeSpan.FromSeconds(8), End = TimeSpan.FromSeconds(28), Speaker = "Bob", Text = "We need to finish the integration tests by Friday. I'll take ownership of the test harness." });
            mt.Transcript.Add(new TranscriptSegment { Start = TimeSpan.FromSeconds(28), End = TimeSpan.FromSeconds(45), Speaker = "Carol", Text = "Can we get the design review done by Wednesday?" });
            return Task.FromResult(mt);
        }


        public Task<Meeting> TranscribeFromAudioBytesAsync(byte[] audioBytes) => TranscribeFileAsync("uploaded-audio.wav");
    }
}