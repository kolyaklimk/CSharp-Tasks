using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{

    abstract class cup
    {
        private int volume;
        private string form;
        public cup(string Form)
        {
            Console.WriteLine("\nСоздан класс 'cup'");
            form = Form;
        }
        public void Print()
        {
            Console.WriteLine("Volume: " + volume + "     Form: " + form + '\n');
        }

        public void PrintClassCup()
        {
            Console.WriteLine("\n(скрытие метода)Тут дожен быть класс 'cup'");
        }

        public abstract void increase(int buf);
        public abstract void decrease(int buf);
        public int Volume
        {
            get
            {
                return volume;
            }
            set { volume = value; }
        }
        public string Form
        {
            get { return form; }
        }

    }

}
