using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    interface IMatrix<T>
    {
        public void ChangeMatrixElement(int i, int j, T newValue);
    }
}
