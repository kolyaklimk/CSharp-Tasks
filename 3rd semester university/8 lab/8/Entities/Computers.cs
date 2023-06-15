using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Entities
{
    internal class Computers
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool suitableBrand { get; set; }

        public Computers(int Id, string Name, bool SuitableBrand)
        {
            id = Id;
            name = Name;
            suitableBrand = SuitableBrand;
        }
    }
}
