using System.Linq;
using System.Text.RegularExpressions;

namespace subtext_finder_lib
{
    public class SubtextFinder
    {
        private static bool isAlphanumeric(string input) {
            return input.Any(char.IsLetterOrDigit);
        }

        public static IList<int> GetIndexesOfMatchedSubtextEx(string text, string subtext)
        {
            int textLength = text.Length;
            List<char> textChars = text.ToCharArray().ToList();
            List<int> indexes = new List<int>();

            for (int i = 0; i < textLength; i++)
            {
                string currentText = new string(textChars.ToArray());
                int currentIndex = currentText.IndexOf(subtext, StringComparison.CurrentCultureIgnoreCase);
                if (currentIndex == 0) {
                    currentIndex += i;
                    indexes.Add(currentIndex);
                }
                textChars.RemoveAt(0);
            }

            return indexes;
        }

        public static IList<int> GetIndexesOfMatchedSubtext(string text, string subtext) {
            if (!isAlphanumeric(subtext)) {
                // handle dot
                if (subtext.Any(e => e == '.'))
                {
                    subtext = subtext.Replace(".", "[.]+");
                }
                if (subtext.Any(e => e == '?')) {
                    subtext = subtext.Replace("?", "[?]+");
                }
            }

            // handle backslash
            if (subtext.Any(e => e == '\\')) {
                subtext = subtext.Replace("\\", "\\\\");
            }

            Regex regex = new Regex(subtext, RegexOptions.IgnoreCase );
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