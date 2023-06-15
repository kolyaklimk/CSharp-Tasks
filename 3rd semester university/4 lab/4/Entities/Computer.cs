using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Entities
{
    internal class Computer
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public bool? IsAvailiableToBuy { get; set; }
        public Computer()
        {
            Price = null;
            IsAvailiableToBuy = null;
            Name = null;
        }
        public Computer(string? name, int? price, bool? isAvailiableToBuy)
        {
            Price = price;
            IsAvailiableToBuy = isAvailiableToBuy;
            Name = name;
        }
        public Computer(string stringFromFile)
        {
            string[] ArrOfData = stringFromFile.Split(' ');
            Name = ArrOfData[0];
            Price = int.Parse(ArrOfData[1]);
            IsAvailiableToBuy = bool.Parse(ArrOfData[2]);
        }
        public override string ToString()
        {
            return this.Name.ToString() +' '+ this.Price.ToString() + ' ' + this.IsAvailiableToBuy.ToString();
        }

    }
}
