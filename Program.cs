using System.ComponentModel;
using static System.Console;
using static TimeTrackeConsoleApp.MenuSystem;

namespace TimeTrackeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Helper.TestCreatingNewPerson();
            //Helper.TestGettingPersonByName();
            //Helper.TestGetListAllPerson();
            //Helper.TestUpdatePerson();
            //Helper.TestDeletePerson();
            //Helper.TestGetHoursByProjectName("coding");
            //Helper.TestGetHoursByPersonName("maria.rosa");
            //Helper.TestUpdateTimeEntry();
            //
            WelcomeMessageScreen();
            DisplayMenu();
        }

        static void WelcomeMessageScreen()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine(@"");
            WriteLine(@"       .'`~~~~~~~~~~~`'.     ");
            WriteLine(@"       (  .'11 12 1'.  )     ");
            WriteLine(@"       |  :10 \    2:  |     ");
            WriteLine(@"       |  :9   @-> 3:  |     ");
            WriteLine(@"       |  :8       4;  |     ");
            WriteLine(@"       '. '..7 6 5..' .'     ");
            WriteLine(@"        ~-------------~      ");
            ResetColor();
            ForegroundColor = ConsoleColor.DarkYellow;
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(@"      ____________________ ");
            WriteLine(@"     |                    |");
            WriteLine(@"     |     WELCOME TO     |");
            WriteLine(@"     |  TIME TRACKER APP  |");
            WriteLine(@"     |____________________|");
            ResetColor();
            WriteLine("\n      Press ENTER to Start");
            ReadLine();
        }

        static void DisplayMenu()
        {
            List<MenuSystem> mainMenuItems = new List<MenuSystem>
            {
                new MenuSystem("Manage Person", ManagePerson),
                new MenuSystem("Manage Project", ManageProject),
                new MenuSystem("Manage Time Entry", ManageTimeEntry),
                new MenuSystem("View Reports", ViewReports),
                new MenuSystem("Exit", Exit)
            };
            bool runMenu = true;
            ConsoleKeyInfo keyInfo;
            int menuIndex = 1;

            while (runMenu)
            {
                Console.Clear();
                MenuSystem.DisplayMenuItems(mainMenuItems, menuIndex);
                keyInfo = Console.ReadKey(true);
                menuIndex = MenuSystem.SelectMenuItemWithArrows(keyInfo, menuIndex, mainMenuItems);
            }

        }

        static void ManagePerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void ManageProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void ManageTimeEntry()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void ViewReports()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("\n\tThank you for using the App. We look forward to your next visit!");
            Thread.Sleep(1000);
            //Environment.Exit(0);
            Console.ReadLine();
        }
        static void GoBackMenuOptions()
        {
            Console.WriteLine("\n\tPress ENTER to go back to the menu.\n");
            Console.ReadLine();
        }
    }
}