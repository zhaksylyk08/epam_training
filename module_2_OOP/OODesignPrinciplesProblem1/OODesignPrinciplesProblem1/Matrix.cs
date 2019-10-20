using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    class Matrix<T> : IMatrix<T>
    {
        public List<List<T>> MatrixElements { get; set; }
        public Matrix(List<List<T>> matrixElements) {
            MatrixElements = matrixElements;
        }

        public T this[int i, int j] {
            get { return MatrixElements[i][j];}
            set { MatrixElements[i][j] = value; }
        }

        public void ChangeMatrixElement(int i, int j, T newValue) {
            MatrixElements[i][j] = newValue;
        }

        // method doesn't check whether matrices can be added or not
        // it can be done at the moment of calling this method
        public Matrix<T> AddTwoMatrices(Matrix<T> anotherMatrix) {
            List<List<T>> answer = new List<List<T>>();
            Matrix<T> resMatrix = new Matrix<T>(answer);
            List<List<dynamic>> firstMatrix = (dynamic)this.MatrixElements;
            List<List<dynamic>> secondMatrix = (dynamic)anotherMatrix.MatrixElements;
            for (int i = 0; i < firstMatrix.Count; i++) {
                for (int j = 0; j < firstMatrix[0].Count; j++)
                    answer[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
            }

            return resMatrix;
        }

        public void DisplayMatrix() {
            List<List<T>> curMatrix = this.MatrixElements;
            for (int i = 0; i < curMatrix.Count; i++) {
                for (int j = 0; j < curMatrix[i].Count; j++)
                    Console.Write("{0} ", curMatrix[i][j]);
                Console.WriteLine();
            }
        }


    }
}
