using Microsoft.VisualStudio.TestTools.UnitTesting;
using creating_types_problem2;

namespace BasicsOfOOPProblem1TestProject
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void SwapMatrixRowsTest()
        {
            // Arrange
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int currentToSwapRow = 0;
            int nextToSwapRow = 1;
            int[,] expectedMatrix = new int[,] { { 4, 5, 6 }, { 1, 2, 3 }, { 7, 8, 9 } };
            // Act
            Program.SwapMatrixRows(ref matrix, currentToSwapRow, nextToSwapRow);
            //Assert
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    Assert.AreEqual(expectedMatrix[i, j], matrix[i, j]);
                }
            }
        }
    }
}
