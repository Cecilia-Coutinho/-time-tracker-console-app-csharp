using System.Globalization;
using static System.Console;

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
                //get person and project name
                string? personName = PersonData.GetPersonFromDB();
                string? projectName = ProjectData.GetProjectFromDB();

                //get timeEntries inputs:
                Console.Write("\n\tEnter Time Entry (in hours): ");
                int.TryParse(Console.ReadLine(), out int timeInHours);

                Console.Write("\n\tEnter Date (dd-MM-yyyy): ");
                string? strDateEntry = Console.ReadLine();

                //validate nullability
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

        static DateTime ParseStringToDate(string? dateString)
        {
            string dateFormat = "dd-MM-yyyy"; //expected date format
            if (string.IsNullOrEmpty(dateString))
            {
                throw new ArgumentException("\n\tInvalid date.");
            }
            return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
        }

        static string ParseDateToString(DateTime date)
        {
            string dateFormat = "dd-MM-yyyy";
            string dateString = date.ToString(dateFormat);
            return dateString;
        }

        public static void UpdateTimeEntry()
        {
            Program.BannerMessageScreen();
            try
            {
                //get person and project name
                string? personName = PersonData.GetPersonFromDB();
                string? projectName = ProjectData.GetProjectFromDB();

                //Display List to get index
                DateTime? oldDate = GetDateEntryByCriteria(personName, projectName);

                //get new inputs
                Console.Write("\n\tEnter the new date (dd-MM-yyyy): ");
                string? newDateString = Console.ReadLine();
                Console.Write("\n\tEnter the new time entry: ");
                int.TryParse(Console.ReadLine(), out int newTimeInHours);

                try
                {
                    DateTime newDate = ParseStringToDate(newDateString);

                    TimeEntryUpdateData updateData = new()
                    {
                        PersonName = personName,
                        ProjectName = projectName,
                        OldDate = oldDate ?? DateTime.MinValue, //to check nullability and set default value
                        NewDate = newDate,
                        NewHours = newTimeInHours
                    };
                    PostgresDataAccess.UpdateTimeEntryData(updateData);

                    Console.WriteLine($"\n\tTime Entry successfully changed:\n " +
                        $"\t{personName}:: {projectName}: {newTimeInHours},  {newDate.ToString("dd-MM-yyyy")}");
                }
                catch (FormatException ex)
                {
                    string invalidFormat = "\n\tDate in wrong format: " + ex.Message;
                    Console.WriteLine(invalidFormat);
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

        static DateTime? GetDateEntryByCriteria(string? personName, string? projectName)
        {
            List<TimeEntryData> getTimeEntriesList = PostgresDataAccess.GetTimeEntryData(personName, projectName);

            DateTime? dateEntry = null;
            bool runMenu = true;
            int menuIndex = 1;


            while (runMenu)
            {
                // Print the menu options
                PrintTimeEntryList(getTimeEntriesList, menuIndex, personName, projectName);

                // Wait for a key press
                ConsoleKeyInfo keyInfo = ReadKey(true);

                // Process the key press
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    dateEntry = getTimeEntriesList[menuIndex - 1].date;
                    runMenu = false;
                }
                else
                {
                    int maxIndexToSelect = getTimeEntriesList.Count;
                    int minIndexToSelect = 1;

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (menuIndex > minIndexToSelect)
                            {
                                menuIndex--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (menuIndex < maxIndexToSelect)
                            {
                                menuIndex++;
                            }
                            break;
                    }
                }
            }
            return dateEntry; // Return the selected date
        }
        static void PrintTimeEntryList(List<TimeEntryData> timeEntries, int selectedIndex, string? personName, string? projectName)
        {
            Clear();
            Program.BannerMessageScreen();
            string menuName = "\n\tSelect from list to Edit";
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine($"\t {menuName.ToUpper()}:");
            ResetColor();

            for (int i = 0; i < timeEntries.Count; i++)
            {
                if (i == selectedIndex - 1)
                {
                    ForegroundColor = ConsoleColor.DarkYellow;
                }

                DateTime date = timeEntries[i].date;
                int timeEntry = timeEntries[i].hours;

                Write($"\n\t {i + 1}. {personName}:: {projectName}: {timeEntry} hrs, {date.ToString("dd-MM-yyyy")}\n");
                ResetColor();
            }
        }
    }

    internal class TimeEntryUpdateData
    {
        public string? PersonName { get; set; }
        public string? ProjectName { get; set; }
        public DateTime OldDate { get; set; }
        public DateTime NewDate { get; set; }
        public int NewHours { get; set; }
    }
}
