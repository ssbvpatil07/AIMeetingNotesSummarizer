using AIMeetingNotesSummarizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Services
{
    public interface ISummarizationService
    {
        Task<Summary> SummarizeAsync(IEnumerable<TranscriptSegment> transcript);
    }
}
