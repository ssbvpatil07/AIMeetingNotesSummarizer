using AIMeetingNotesSummarizer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AIMeetingNotesSummarizer.Services
{
    public class SimpleSummarizationService : ISummarizationService
    {
        public Task<Summary> SummarizeAsync(IEnumerable<TranscriptSegment> transcript)
        {
            var s = new Summary();
            var allText = string.Join(" ", transcript.Select(t => t.Text));
            // Naive sentence split
            var sentences = Regex.Split(allText, @"(?<=[\.\!\?])\s+");
            s.ShortSummary = string.Join(" ", sentences.Take(2));
            s.BulletPoints = sentences.Take(6).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            s.ActionItems = transcript.SelectMany(t => Regex.Split(t.Text, @"(?<=[\.\!\?])\s+"))
            .Where(sent => Regex.IsMatch(sent, @"\b(need|will|must|action|todo|assign|ownership|take ownership)\b", RegexOptions.IgnoreCase))
            .Select(sent => new ActionItem { Description = sent.Trim() })
            .ToList();
            return Task.FromResult(s);
        }
    }
}
