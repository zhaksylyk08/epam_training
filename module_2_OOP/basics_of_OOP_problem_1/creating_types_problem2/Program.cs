using System;

namespace creating_types_problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 9, 9, 9}, { 3, 4, 1}, { 5, 6, 10 }, { 1, 0, 1 } };
            BubbleSortOnMatrixByRowMin(ref matrix, false);
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0} ", matrix[i, j]);
                Console.WriteLine();
            }
        }

        // sorts matrix rows by row sum; default ordering is ascending
        public static void BubbleSortOnMatrixByRowSum(ref int[,] matrix, bool isAscendingOrder = true) { 
            for (int i = 0; i < matrix.GetLength(0); i++) {
                int curRowSum = 0, nextRowSum = 0;
                for (int cur = 0; cur < matrix.GetLength(0) - 1; cur++) {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        curRowSum += matrix[cur, j];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        nextRowSum += matrix[cur + 1, j];
                    if (isAscendingOrder)
                    {
                        if (curRowSum > nextRowSum)
                            SwapMatrixRows(ref matrix, cur, cur + 1);
                    }
                    else {
                        if (curRowSum < nextRowSum)
                            SwapMatrixRows(ref matrix, cur, cur + 1);
                    }
                    nextRowSum = 0;
                    curRowSum = 0;
                }
            }
        }


        public static void SwapMatrixRows(ref int[,] matrix, int curRow, int nextRow) {
            int colNums = matrix.GetLength(1);
            int[] tempArr = new int[colNums];
            for (int i = 0; i < colNums; i++)
                tempArr[i] = matrix[curRow, i];
            for (int i = 0; i < colNums; i++)
                matrix[curRow, i] = matrix[nextRow, i];
            for (int i = 0; i < colNums; i++)
                matrix[nextRow, i] = tempArr[i];
        }

        // sorting matrix rows by max row's max element; default ordering is ascending
        public static void BubbleSortOnMatrixByRowMax(ref int[,] matrix, bool isAscendingOrder = true) {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int curRowMax, nextRowMax;
                for (int cur = 0; cur < matrix.GetLength(0) - 1; cur++)
                {
                    curRowMax = matrix[cur, 0];
                    nextRowMax = matrix[cur + 1, 0];
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        if (matrix[cur, j] > curRowMax)
                            curRowMax = matrix[cur, j];
                    }
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        if (matrix[cur + 1,  j] > nextRowMax)
                            nextRowMax = matrix[cur + 1,  j];
                    }
                    if (isAscendingOrder)
                    {
                        if (curRowMax > nextRowMax)
                            SwapMatrixRows(ref matrix, cur, cur + 1);
                    }
                    else
                    {
                        if (curRowMax < nextRowMax)
                            SwapMatrixRows(ref matrix, cur, cur + 1);
                    }
                }
            }
        }

        // sorting matrix rows by row's min element; default ordering is ascendings
        public static void BubbleSortOnMatrixByRowMin(ref int[,] matrix, bool isAscendingOrder = true)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int curRowMin, nextRowMin;
                for (int cur = 0; cur < matrix.GetLength(0) - 1; cur++)
                {
                    curRowMin = matrix[cur, 0];
                    nextRowMin = matrix[cur + 1, 0];
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[cur, j] < curRowMin)
                            curRowMin = matrix[cur, j];
                    }
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[cur + 1, j] < nextRowMin)
                            nextRowMin = matrix[cur + 1, j];
                    }
                    if (isAscendingOrder)
                    {
                        if (curRowMin > nextRowMin)
                            SwapMatrixRows(ref matrix, cur, cur + 1);
                    }
                    else
                    {
                        if (curRowMin < nextRowMin)
                            SwapMatrixRows(ref matrix, cur, cur + 1);
                    }
                }
            }
        }
    }
}
