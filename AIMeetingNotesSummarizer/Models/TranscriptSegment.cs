using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Models
{
    public class TranscriptSegment
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Speaker { get; set; } = "Unknown";
        public string Text { get; set; } = "";
    }
}
