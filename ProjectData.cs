using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackeConsoleApp
{
    internal class ProjectData
    {
        public int id { get; set; }
        public string? project_name { get; set; }

        public static void CreateProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void UpdateProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
