using System.Text.RegularExpressions;

namespace subtext_finder_lib
{
    public class SubtextFinder
    {
        public static IList<int> GetIndexesOfMatchedSubtext(string text, string subtext) {
            Regex regex = new Regex(subtext);
            List<int> result = new List<int>();

            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                result.Add(match.Index);
            }

            return result;
        }
    }
}