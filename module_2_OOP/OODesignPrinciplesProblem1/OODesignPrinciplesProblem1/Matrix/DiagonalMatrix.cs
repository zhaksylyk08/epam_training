using System;
using System.Collections.Generic;
using System.Text;

namespace OODesignPrinciplesProblem1
{
    class DiagonalMatrix : SquareMatrix
    {
        public DiagonalMatrix(int size) : base(size) { }

        public int this[int pos] 
        {
            get { return base[pos, pos]; }
            set { base[pos, pos] = value; }
        }

        public override int this[int i, int j] 
        {
            get => base[i, j];
            set 
            {
                if (i != j) 
                {
                    throw new ArgumentException("In diagonal matrix only elements at diagonal can be specified");
                }
                base[i, i] = value;
            }
        }
    }
}
