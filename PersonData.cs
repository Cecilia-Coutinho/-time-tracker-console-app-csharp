using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackeConsoleApp
{
    internal class PersonData
    {
        public int id { get; set; }
        public string? person_name { get; set; }

        public static void AddPerson()
        {
            Program.BannerMessageScreen();

            Console.Write("\n\tEnter username (UNIQUE): ");
            string? personName = Console.ReadLine()?.ToLower();
            if (string.IsNullOrWhiteSpace(personName))
            {
                Console.WriteLine($"\n\tError: Name can not be null.\n");
                return;
            }
            else
            {
                Console.Clear();
                string menuName = $"Confirm Person Creation {personName}:";
                List<MenuSystem> selectToConfirmItems = new()
                {
                    // If the user selects "Yes", create new PersonData object and try to add it to the database
                    new MenuSystem("Yes", () =>
                    {
                        PersonData person = new()
                        {
                            person_name = personName,
                        };
                        try
                        {
                            // Call the PostgresDataAccess to add the new person to the database
                            bool success = PostgresDataAccess.CreateNewPersonData(person);
                            if (success)
                            {
                                Console.WriteLine($"\tNew person successfully added: {person.person_name}");
                                Console.WriteLine("\n\tPress ENTER to continue...");
                                Console.ReadLine();
                                Program.ManagePersonMenu();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n\tError: The provided name is either already in use\n" +
                                $"\tor exceeds the maximum length of 25 characters.\n" +
                                $"\t{ex.Message}");
                            Console.ResetColor();
                            Console.WriteLine("\n\tPress ENTER to continue...");
                            Console.ReadLine();
                            Program.ManagePersonMenu();
                        }
                    }),

                    new MenuSystem("No", Program.ManagePersonMenu)
                };

                MenuSystem.RunMenu(menuName, selectToConfirmItems);
            }
        }

        public static void UpdatePerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void DisplayAllPersons()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void DisplayPersonByProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
