using _153504_KLIMKOVICH_Lab9.Domain.Entities;
using Serialize;

namespace _153504_KLIMKOVICH_Lab9
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listOfComputers = new List<Computer>();
            listOfComputers.Add(new Computer("Apple", new Winchester("SFT23", 763)));
            listOfComputers.Add(new Computer("Dell", new Winchester("AMERICWIN", 25)));
            listOfComputers.Add(new Computer("ASUS", new Winchester("HIGTH107", 72)));
            listOfComputers.Add(new Computer("Lenovo", new Winchester("DDLL43", 6)));
            listOfComputers.Add(new Computer("Huawei", new Winchester("BELWIN", 7453)));

            var serializer = new Serializer();
            serializer.SerializeJSON(listOfComputers, "computers.json");

            Console.WriteLine("/////JSON:");
            foreach (var item in serializer?.DeSerializeJSON("computers.json")?.ToList())
            {
                Console.WriteLine($"Name: {item.name}\nTypeOfWinchesters: {item?.winchester?.name}\nPrice: {item?.winchester?.price}\n");
            }

            serializer?.SerializeByLINQ(listOfComputers, "computers(LINQ).xml");

            Console.WriteLine("/////XML(LINQ)");
            foreach (var item in serializer?.DeSerializeByLINQ("computers(LINQ).xml"))
            {
                Console.WriteLine($"Name: {item.name}\nTypeOfWinchesters: {item?.winchester?.name}\nPrice: {item?.winchester?.price}\n");
            }

            serializer?.SerializeXML(listOfComputers, "computers.xml");

            Console.WriteLine("/////Common XML:");
            foreach (var item in serializer?.DeSerializeXML("computers.xml"))
            {
                Console.WriteLine($"Name: {item.name}\nTypeOfWinchesters: {item?.winchester?.name}\nPrice: {item?.winchester?.price}\n");
            }
        }
    }
}