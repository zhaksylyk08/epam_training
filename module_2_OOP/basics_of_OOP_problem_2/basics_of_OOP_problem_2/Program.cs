using System;

namespace basics_of_OOP_problem_2
{
    class Program
    {
        static void Main(string[] args)
        { 
            IShape shape = new Rectangle(2, 3);
            double area = shape.CalculateArea();
            Console.Write("area of rectangle = {0}\n", area);

            shape = new Circle(3);
            area = shape.CalculateArea();
            Console.Write("area of triangle = {0}", area);
        }
    }
}
