using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Models
{
    public class ActionItem
    {
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
    }
}
