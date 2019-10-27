using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem2;

namespace ConvertToTestCaseProjectTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ConvertToTitleCase_With_MinorWords()
        {
            // Arrange
            string s = "THE WIND IN THE WILLOWS";
            string minorWords = "The In";
            string expected = "The Wind in the Willows";
            //Act
            string actual = Program.ConvertToTitleCase(s, minorWords);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
