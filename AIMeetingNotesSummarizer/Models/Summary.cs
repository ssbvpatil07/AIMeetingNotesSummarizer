using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Models
{
    public class Summary
    {
        public string ShortSummary { get; set; } = "";
        public List<string> BulletPoints { get; set; } = new();
        public List<ActionItem> ActionItems { get; set; } = new();
    }
}
