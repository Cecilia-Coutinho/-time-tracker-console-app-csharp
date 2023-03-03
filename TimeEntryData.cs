using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackeConsoleApp
{
    internal class TimeEntryData
    {
        public int id { get; set; }
        public int project_id { get; set; }
        public int person_id { get; set; }
        public int hours { get; set; }
        public DateTime date { get; set; }

        public static void CreateTimeEntry()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void UpdateTimeEntry()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
