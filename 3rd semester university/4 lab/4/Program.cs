using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4.Entities;
using _4.MyCustomCollections;

namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listOfComputers = new List<Computer>();
            listOfComputers.Add(new Computer("ASUS", 404, true));
            listOfComputers.Add(new Computer("DELL", 1337, true));
            listOfComputers.Add(new Computer("Lenovo", 43, false));
            listOfComputers.Add(new Computer("Huawei", 1313, true));
            listOfComputers.Add(new Computer("Apple", 10000, true));
            listOfComputers.Add(new Computer("jet", 808, false));

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                + "/Computers.dat";
            string newPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                + "/NewComputers.dat";

            FileService<Computer> service = new FileService<Computer>();
            service.SaveData(listOfComputers, path);

            File.Delete(newPath);
            File.Move(path,newPath);

            List<Computer> newListOfComputers = new List<Computer>();
            newListOfComputers = service.ReadFile(newPath).ToList();

            Console.WriteLine("\nИсходная коллекция:");
            foreach (var item in newListOfComputers)
            {
                Console.WriteLine(item);
            }

            newListOfComputers = newListOfComputers.OrderBy(x => x, new MyCustomComparer<Computer>()).ToList();

            Console.WriteLine("\nОтсортированная коллекция (Name):");
            foreach (var item in newListOfComputers)
            {
                Console.WriteLine(item);
            }

            newListOfComputers = newListOfComputers.OrderBy(x => x.Price).ToList();

            Console.WriteLine("\nОтсортированная коллекция (Price):");
            foreach (var item in newListOfComputers)
            {
                Console.WriteLine(item);
            }

            File.Delete(newPath);
        }
    }
}
