using Lab_1.Other;
using System;
using System.IO;
using System.Text;

namespace Lab_1.Task4
{
    public static class Task4
    {
        public static void StartTask()
        {
            MyConsole.printTasks(4);
            CreateFile();
        }

        public static string GenerateHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<html>" +
                "<head>" +
                "<style>" +
                "table {" +
                "  border-collapse: collapse;" +
                "  width: 100%;" +
                "}" +
                "</style>" +
                "</head>" +
                "<body>" +
                "<body>" +
                "<table>");

            for (int i = 0; i < 255; i++)
            {
                int red = 255 - i;
                int green = 255 - i;
                int blue = 255 - i;
                string backgroundColor = $"rgb({red}, {green}, {blue})";

                sb.AppendLine("<tr style=\"background-color: " + backgroundColor + "; font-size: 1px;\">");
                sb.AppendLine("<td>Строка " + (i + 1) + "</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>" +
                "</body>" +
                "</html>");

            return sb.ToString();
        }

        public static void CreateFile()
        {
            using (FileStream fs = File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "file.html")))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(GenerateHtml());
                fs.Write(info, 0, info.Length);
            }
            Console.WriteLine("file.html in desktop was created");
        }
    }
}