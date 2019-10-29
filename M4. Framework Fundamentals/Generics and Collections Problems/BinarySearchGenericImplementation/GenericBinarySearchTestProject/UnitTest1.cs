using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchGenericImplementation;

namespace GenericBinarySearchTestProject
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void GenericBinarySearchTest_With_ValueTypeParameter()
        {
            //Arrange
            var arr = new int[] { 1, 3, 5, 7, 9 };
            int x = 1;
            int expectedIndex = 0;
            //Act
            int actualIndex = Program.GenericBinarySearch(ref arr, x);
            //Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }
    }
}
