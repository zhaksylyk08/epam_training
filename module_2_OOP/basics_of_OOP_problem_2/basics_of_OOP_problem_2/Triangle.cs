using System;
using System.Collections.Generic;
using System.Text;

namespace basics_of_OOP_problem_2
{
    class Triangle: IShape
    {
       public double FirstSide { get; set; }
       public double SecondSide { get; set; }
       public double BaseSide { get; set; }
       public double Height { get; set; }

        public Triangle() { }
        public Triangle(double firstSide, double secondSide,
                        double baseSide, double height)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            BaseSide = baseSide;
            Height = height;
        }

        public double CalculateArea() => BaseSide * Height / 2;
        public double CalculatePerimeter() => FirstSide + SecondSide + BaseSide;
    }
}
