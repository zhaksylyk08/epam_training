using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem3;

namespace Problem3TestProject
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void AddOrChangeUrlParameterTest()
        {
            //Arrange
            string url = "www.example.com?key=value";
            string keyValueParameters = "key2=value2";
            string expected = "www.example.com?key=value&key2=value2";
            //Act
            string actual = Program.AddOrChangeUrlParameter(url, keyValueParameters);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
