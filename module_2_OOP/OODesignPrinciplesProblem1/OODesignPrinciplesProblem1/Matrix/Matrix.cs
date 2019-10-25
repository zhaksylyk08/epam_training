using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    public class Matrix
    {
        private List<List<int>> MatrixElements { get; set; }
        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }

        public Matrix(int numberOfRows, int numberOfColumns) 
        {
            MatrixElements = new List<List<int>>();
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;

            for (int i = 0; i < NumberOfRows; i++) 
            {
                var row = new List<int>();
                for (int j = 0; j < numberOfColumns; j++) 
                {
                    row.Add(0);
                }
                MatrixElements.Add(row);
            }

        }

        public virtual int this[int i, int j] 
        {
            get { return MatrixElements[i][j]; }
            set { MatrixElements[i][j] = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < NumberOfRows; i++) 
            {
                var row = MatrixElements[i];
                sb.AppendLine(string.Join(" ", row));
            }
            return sb.ToString();
        }

        public static Matrix operator +(Matrix m1, Matrix m2) 
        {
            if (m1.NumberOfRows != m2.NumberOfRows ||
                m1.NumberOfColumns != m2.NumberOfColumns)
            {
                throw new ArgumentException("Matrix sizes must be the same");
            }

            var result = new Matrix(m1.NumberOfRows, m1.NumberOfColumns);

            for (int i = 0; i < m1.NumberOfRows; i++) 
            {
                for (int j = 0; j < m1.NumberOfColumns; j++) 
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return result;
        }
    }
}
