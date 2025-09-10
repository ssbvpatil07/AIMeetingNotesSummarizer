using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Models
{
    public class Meeting
 {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "Untitled Meeting";
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public List<TranscriptSegment> Transcript { get; set; } = new();
    public Summary Summary { get; set; } = new Summary();
}
}