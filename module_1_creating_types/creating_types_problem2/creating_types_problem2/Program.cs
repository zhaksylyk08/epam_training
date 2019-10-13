using System;

namespace creating_types_problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 9, 9, 9}, { 3, 4, 1}, { 5, 6, 10 }, { 1, 0, 1 } };
            bubbleSortOnMatrixByIncrRowSum(ref matrix);
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0} ", matrix[i, j]);
                Console.WriteLine();
            }
        }

        // sorts matrix rows by ascending row sum
        public static void bubbleSortOnMatrixByIncrRowSum(ref int[,] matrix) { 
            for (int i = 0; i < matrix.GetLength(0); i++) {
                int curRowSum = 0, nextRowSum = 0;
                for (int cur = 0; cur < matrix.GetLength(0) - 1; cur++) {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        curRowSum += matrix[cur, j];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        nextRowSum += matrix[cur + 1, j];
                    if (curRowSum > nextRowSum)
                        swapMatrixRows(ref matrix, cur, cur + 1);
                    nextRowSum = 0;
                    curRowSum = 0;
                }
            }
        }

        public static void swapMatrixRows(ref int[,] matrix, int curRow, int nextRow) {
            int colNums = matrix.GetLength(1);
            int[] tempArr = new int[colNums];
            for (int i = 0; i < colNums; i++)
                tempArr[i] = matrix[curRow, i];
            for (int i = 0; i < colNums; i++)
                matrix[curRow, i] = matrix[nextRow, i];
            for (int i = 0; i < colNums; i++)
                matrix[nextRow, i] = tempArr[i];
        }
    }
}
