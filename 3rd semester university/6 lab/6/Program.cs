using _6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _6
{
    public class Program
    {
        static void Main(string[] arg)
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee(21, true, "Nikolay"));
            employees.Add(new Employee(64, true, "Anton"));
            employees.Add(new Employee(32, false, "Valeria"));
            employees.Add(new Employee(37, true, "Ekaterina"));
            employees.Add(new Employee(54, true, "Nikita"));
            employees.Add(new Employee(58, false, "Maxim"));

            Assembly assembly = Assembly.LoadFrom("FileService.dll");
            Type? type = assembly.GetType("FileService.FileService`1")?.MakeGenericType(typeof(Employee));

            if (type != null)
            {
                object instance = Activator.CreateInstance(type);

                MethodInfo readFile = type.GetMethod("ReadFile");
                MethodInfo saveData = type.GetMethod("SaveData");

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                    + "/Computers.json";

                saveData?.Invoke(instance, new object[] { employees, path});

                var newList = 
                    ((IEnumerable<Employee>)readFile.Invoke(instance, new object[] { path }));

                foreach(var e in newList)
                {
                    Console.WriteLine(
                        $"Age: {e.age.ToString()}, Name: {e.name}, AbleToWork: {e.ableToWork.ToString()}");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}