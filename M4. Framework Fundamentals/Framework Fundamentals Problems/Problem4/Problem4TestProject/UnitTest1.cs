using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem4;
using System.Collections.Generic;

namespace Problem4TestProject
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void UniqueInOrderTest()
        {
            //Arrange
            string s = "AAAABBBCCDAABBB";
            var expected = new List<char>() { 'A', 'B', 'C', 'D', 'A', 'B' };
            //Act
            var actual = Program.UniqueInOrder(s);
            //Assert
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
