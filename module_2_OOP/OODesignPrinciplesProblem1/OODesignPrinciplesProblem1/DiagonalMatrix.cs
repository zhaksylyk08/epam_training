using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(List<List<T>> matrixElements) : base(matrixElements) { }
    }
}
