using System;
using System.Collections.Generic;

namespace OODesignPrinciplesProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrixElements1 = new List<List<int>>();
            List<int> firstRow = new List<int>();
            List<int> secondRow = new List<int>();
            for (int i = 0; i < 3; i++)
                firstRow.Add(i);
            for (int i = 3; i < 6; i++)
                secondRow.Add(i);
            matrixElements1.Add(firstRow);
            matrixElements1.Add(secondRow);
            
            Matrix<int> m = new Matrix<int>(matrixElements1);
            m.DisplayMatrix();
            Matrix<int> m2 = new Matrix<int>(matrixElements1);
            Matrix<int> res = m.AddTwoMatrices(m2);
            res.DisplayMatrix();
        }
    }
}
