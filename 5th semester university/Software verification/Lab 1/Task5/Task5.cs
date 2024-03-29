﻿using Lab_1.Other;
using System;
using System.IO;
using System.Text;

namespace Lab_1.Task5
{
    public static class Task5
    {
        public static void StartTask()
        {
            MyConsole.PrintTasks(5);
            Work();
        }

        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool ExtensionExists(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            return true;
        }

        public static string Find(string path, string extension)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var file in Directory.EnumerateFiles(path, extension, SearchOption.AllDirectories))
            {
                sb.AppendLine(file);
            }
            return sb.ToString();
        }

        public static void Work()
        {
            string path;
            while (true)
            {
                Console.WriteLine("Print directory path (For example: c:/dir1/dir2/ ) :");
                path = Console.ReadLine();
                if (DirectoryExists(path))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error, try again");
                }
            }

            string extension;
            while (true)
            {
                Console.WriteLine("Print extension (For example: png ) :");
                extension = Console.ReadLine();
                if (ExtensionExists(extension))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error, try again");
                }
            }

            Console.WriteLine(Find(path, $"*.{extension}"));
        }
    }
}
