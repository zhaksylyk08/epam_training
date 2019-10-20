using System;
using System.Collections.Generic;
using System.Text;

namespace basics_of_OOP_problem_2
{
    class Rectangle: IShape
    {
        private double height;
        private double width;

        public Rectangle() { }
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double CalculateArea() => Height * Width;
        public double CalculatePerimeter() => 2 * Height * Width;
    }
}
