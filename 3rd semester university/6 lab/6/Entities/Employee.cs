using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _6.Entities
{
    public class Employee
    {
        public int age { get; set; }

        public string name { get; set; }
        public bool ableToWork { get; set; }

        public Employee(int age, bool ableToWork, string name)
        {
            this.age = age;
            this.ableToWork = ableToWork;
            this.name = name;
        }
    }
}
