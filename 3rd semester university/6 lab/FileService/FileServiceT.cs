using _6.Interfaces;
using System.Text.Json;

namespace FileService
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            using FileStream file = new FileStream(fileName, FileMode.Open);

            return JsonSerializer.Deserialize<IEnumerable<T>>(file);

        }
        public void SaveData(IEnumerable<T> data, string fileName)
        {
            using FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);

            JsonSerializer.Serialize(file, data);
        }
    }
}
