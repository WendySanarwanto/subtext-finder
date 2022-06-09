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
    }
}