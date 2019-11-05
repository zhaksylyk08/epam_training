using System;
using System.Collections.Generic;
using System.Text;

namespace Problem1
{
    public class Employee
    {
        private int id;
        private string name;
        private static CompanyPolicy policy;

        public int Id { get { return id; } }
        public string Name { get { return name; } }

        public Employee(int id, string name) 
        {
            this.id = id;
            this.name = name;
        }

        public virtual void Work()
        {
            Console.WriteLine("Working...");
        }

        public void TakeVacation(int days) 
        {
            Console.WriteLine("Taking vacation...");
        }

        public static void SetCompanyPolicy(CompanyPolicy plc) 
        {
            policy = plc;
        }

        public override string ToString()
        {
            return string.Format("Employee record: id = {0}, name = {1}", id, name);
        }
    }
}
