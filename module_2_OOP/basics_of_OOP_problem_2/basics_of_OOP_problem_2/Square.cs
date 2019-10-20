using System;
using System.Collections.Generic;
using System.Text;

namespace basics_of_OOP_problem_2
{
    class Square: IShape
    {
        private double sideLength;
        public Square() { }
        public Square(double sideLength) {
            this.sideLength = sideLength;
        }
        public double SideLength {
            get { return sideLength; }
            set { sideLength = value; }
        }

        public double CalculateArea() => Math.Pow(SideLength, 2);

        public double CalculatePerimeter() => 4 * SideLength;

    }
}
