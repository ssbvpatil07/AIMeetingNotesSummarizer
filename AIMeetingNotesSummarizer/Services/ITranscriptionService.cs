using AIMeetingNotesSummarizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Services
{
    public interface ITranscriptionService
    {
        Task<Meeting> TranscribeFileAsync(string filePath);
        Task<Meeting> TranscribeFromAudioBytesAsync(byte[] audioBytes);
    }
}
