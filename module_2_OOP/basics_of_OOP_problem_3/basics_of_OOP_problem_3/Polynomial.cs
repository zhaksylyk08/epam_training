using System;
using System.Collections.Generic;
using System.Text;

namespace basics_of_OOP_problem_3
{
    class Polynomial
    {
        public int Degree { get; set; }
        public List<int> Coefficients { get; set; }

        public Polynomial(int degree, List<int> coefficients) {
            this.Degree = degree;
            this.Coefficients = coefficients;
        }

        public override string ToString()
        {
            string answer = "y = ";
            int curDegree = Degree;
            foreach (int coeff in Coefficients) {
                 answer += coeff + "x^" + curDegree;
                if (curDegree > 0)
                    answer += " + ";
                 curDegree--;
            }
            return answer;
        }

    }
}
