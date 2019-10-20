using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(List<List<T>> matrixElements) : base(matrixElements) { }
    }
}
