using System;
using System.Collections.Generic;
using System.Text;

namespace basics_of_OOP_problem_2
{
    class Circle: IShape
    {
        private double radius;

        public Circle() { }
        public Circle(double radius) {
            this.radius = radius;
        }
        public double Radius {
            get { return radius; }
            set { radius = value; }
        }
        public double CalculateArea() => Math.Round((Math.PI * Math.Pow(Radius, 2)), 2) ;
        public double CalculatePerimeter() => Math.Round((2 * Math.PI * Radius), 2);
    }
}
