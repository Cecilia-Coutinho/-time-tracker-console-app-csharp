using System.Globalization;

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
            Program.BannerMessageScreen();
            try
            {
                Console.Write("\n\tEnter Person Name: ");
                string? personName = Console.ReadLine();
                // Get person data from database
                PersonData getPerson = PostgresDataAccess.GetPersonDataByName(personName?.ToLower());

                Console.Write("\n\tEnter Project Name: ");
                string? projectName = Console.ReadLine();
                // Get project data from database
                ProjectData getProject = PostgresDataAccess.GetProjectDataByName(projectName?.ToLower());


                Console.Write("\n\tEnter Time Entry (in hours): ");
                int.TryParse(Console.ReadLine(), out int timeInHours);

                Console.Write("\n\tEnter Date (dd-MM-yyyy): ");
                string? strDateEntry = Console.ReadLine();

                if (
                    string.IsNullOrEmpty(personName) ||
                    string.IsNullOrEmpty(projectName) ||
                    string.IsNullOrEmpty(strDateEntry)
                    )
                {
                    Console.WriteLine($"\n\tError: It's not a valid input.\n");
                    return;
                }
                else
                {
                    try
                    {
                        DateTime dateEntry = ParseStringToDate(strDateEntry);
                        TimeEntryData newTimeEntry = new()
                        {
                            hours = timeInHours,
                            date = dateEntry
                        };

                        PostgresDataAccess.CreateNewTimeEntryData(personName, projectName, newTimeEntry);
                        Console.WriteLine($"\n\tNew time Entry successfully added:\n " +
                            $"\t{personName}:: {projectName}: {timeInHours}, {dateEntry.ToString("dd-MM-yyyy")}");

                    }
                    catch (FormatException ex)
                    {
                        string invalidFormat = "\n\tDate in wrong format: " + ex.Message;
                        Console.WriteLine(invalidFormat);
                    }
                }
            }
            catch (Exception ex) //error handling for database errors
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError: The provided data is not valid\n" +
                    $"\tplease check your inputs and try again.\n" +
                    $"\t{ex.Message}");
                Console.ResetColor();
            }
        }

        static DateTime ParseStringToDate(string dateString)
        {
            string dateFormat = "dd-MM-yyyy"; //expected date format
            return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
        }

        //static string ParseDateToString(DateTime date)
        //{
        //    string dateFormat = "dd-MM-yyyy";
        //    string dateString = date.ToString(dateFormat);
        //    return dateString;
        //}

        public static void UpdateTimeEntry()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void DisplayAllTimeEntriesByPerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void DisplayAllTimeEntriesByProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
