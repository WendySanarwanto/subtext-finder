using subtext_finder_lib;

namespace subtext_finder
{
    [TestClass]
    public class SubtextFinderTest
    {
        [TestMethod]
        public void Find2SubtextWithinASentenceTest()
        {
            string text = "Hello Wendy Sanarwanto. How are you today, Wendy ?";
            string subtext = "Wendy";
            int[] expected = new int[] { 6, 43 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);

            CollectionAssert.AreEquivalent(actual.ToArray(), expected);

        }

        [TestMethod]
        public void Find2SubtextWithinAWordTest() {
            string text = "HelloWendySanarwanto.Howareyoutoday,Wendy?";
            string subtext = "Wendy";
            int[] expected = new int[] { 5, 36 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindPartialCharsWithinASentenceIgnoreCasingTest() {
            string text = "Beauty and beast";
            string subtext = "Ea";
            int[] expected = new int[] { 1, 12 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindSpacesWithinASentenceTest() {
            string text = "Beauty and beast";
            string subtext = " ";
            int[] expected = new int[] { 6, 10 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindAnumberInMixedNumericAndNonAlphanumbericStringTest()
        {
            string text = "124523786^&$%&%#987230123";
            string subtext = "1";
            int[] expected = new int[] { 0, 22 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindDotOnDotsSpacesTest()
        {
            string text = ". . . ";
            string subtext = ".";
            int[] expected = new int[] { 0, 2, 4 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindDoubleQuotesTest()
        {
            string text = @"ignore""eeyore""bored";
            string subtext = @"e""";
            int[] expected = new int[] { 5, 12 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindSlashDotsTest() {
            string text = @"//.\\.//.\\";
            string subtext = @"/.";
            int[] expected = new int[] { 1, 7 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindDotSlashTest() { 
            string text = @"//.\\.//.\\";
            string subtext = @".\";
            int[] expected = new int[] { 2, 8 };

            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

        [TestMethod]
        public void FindQuestionSubtextTest() {
            string text = @"How are you today ?"; 
            string subtext = @"?";
            int[] expected = new int[] { 18 };
            IList<int> actual = SubtextFinder.GetIndexesOfMatchedSubtext(text, subtext);
            CollectionAssert.AreEquivalent(actual.ToArray(), expected);
        }

    }
}