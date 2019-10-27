using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem1;

namespace CustomerTestProject
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void ToString_WithNoFormatParameter()
        {
            // Arrange
            string expected = "Customer record: Jeffrey Ritcher, 1,000,000.00, +1(425)555-0100";
            var testCustomer = new Customer("Jeffrey Ritcher", 1000000, "+1(425)555-0100");
            //Act
            var actual = testCustomer.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
