using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    class SymmetricMatrix : SquareMatrix
    {
        public SymmetricMatrix(int size) : base(size) { }

        public override int this[int i, int j] 
        {
            get { return base[i, j]; }
            set
            {
                base[i, j] = value;
                base[j, i] = value;
            }
        }
    }
}
