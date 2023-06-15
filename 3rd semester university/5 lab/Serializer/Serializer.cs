using System.Text.Json;
using System.Xml.Serialization;
using System.Xml.Linq;
using _153504_KLIMKOVICH_Lab9.Domain.Entities;
using _153504_KLIMKOVICH_Lab9.Domain.Interfaces;

namespace Serialize
{
    public class Serializer : ISerializer
    {
        public IEnumerable<Computer> DeSerializeByLINQ(string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);
            var comp = from computer in xdoc?.Element("computers")?.Elements("computer")
                        select new Computer(
                            computer?.Element("name")?.Value,
                            new Winchester(
                            computer?.Element("winchester")?.Element("name")?.Value,
                            int.Parse(computer?.Element("winchester")?.Element("price")?.Value)
                        ));
            return comp;
        }

        public IEnumerable<Computer> DeSerializeJSON(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IEnumerable<Computer>>(json);
        }

        public IEnumerable<Computer> DeSerializeXML(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Computer>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                IEnumerable<Computer>? list = xmlSerializer.Deserialize(fs) as IEnumerable<Computer>;
                return list;
            }
        }

        public void SerializeByLINQ(IEnumerable<Computer> computers, string fileName)
        {
            XDocument xdoc = new XDocument(new XElement("computers",
                                            from listItem in computers
                                            select new XElement("computer",
                                                new XElement("name", listItem.name),
                                                new XElement("winchester",
                                                    new XElement("name", listItem?.winchester?.name),
                                                    new XElement("price", listItem?.winchester?.price)))));
            xdoc.Save(fileName);

        }

        public void SerializeJSON(IEnumerable<Computer> computers, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(computers, options);
            File.WriteAllText(fileName, json);
        }

        public void SerializeXML(IEnumerable<Computer> computers, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Computer>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, computers);
            }
        }
    }
}