﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(List<List<T>> matrixElements) : base(matrixElements) { }

    }
}
