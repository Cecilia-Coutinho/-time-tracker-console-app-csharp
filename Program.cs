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
            //Helper.TestUpdateTimeEntry();//
            WelcomeMessageScreen();
            DisplayMainMenu();
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

        static void DisplayMainMenu()
        {
            Thread.Sleep(20);
            string menuName = "Main Menu";
            List<MenuSystem> mainMenuItems = new List<MenuSystem>
            {
                new MenuSystem("Manage Person", ManagePersonMenu),
                new MenuSystem("Manage Project", ManageProjectMenu),
                new MenuSystem("Manage Time Entry", ManageTimeEntryMenu),
                new MenuSystem("View Reports", ViewReportsMenu),
                new MenuSystem("Exit", Exit)
            };

            MenuSystem.RunMenu(menuName, mainMenuItems);
        }

        static void ManagePersonMenu()
        {
            string menuName = "Manage Person Menu";
            List<MenuSystem> managePersonMenuItems = new List<MenuSystem>
            {
                new MenuSystem("Create Person", PersonData.CreatePerson),
                new MenuSystem("Edit Person", PersonData.UpdatePerson),
                new MenuSystem("Exit", DisplayMainMenu)
            };
            RunMenu(menuName, managePersonMenuItems);
        }

        static void ManageProjectMenu()
        {
            string menuName = "Manage Project Menu";
            List<MenuSystem> manageProjectMenuItems = new List<MenuSystem>
            {
                new MenuSystem("Create Project", ProjectData.CreateProject),
                new MenuSystem("Edit Project", ProjectData.UpdateProject),
                new MenuSystem("Exit", DisplayMainMenu)
            };
            RunMenu(menuName, manageProjectMenuItems);
        }

        static void ManageTimeEntryMenu()
        {
            string menuName = "Manage Time Entry Menu";
            List<MenuSystem> manageTimeEntryMenuItems = new List<MenuSystem>
            {
                new MenuSystem("Create Time Entry", TimeEntryData.CreateTimeEntry),
                new MenuSystem("Edit Time Entry", TimeEntryData.UpdateTimeEntry),
                new MenuSystem("Exit", DisplayMainMenu)
            };
            RunMenu(menuName, manageTimeEntryMenuItems);
        }

        static void ViewReportsMenu()
        {
            string menuName = "View Report Menu";
            List<MenuSystem> viewReportsMenuItems = new List<MenuSystem>
            {
                new MenuSystem("View Persons Report", PersonReportMenu),
                new MenuSystem("View Projects Report", ProjectReportMenu),
                new MenuSystem("View Time Entries Report", TimeEntryReportMenu),
                new MenuSystem("Exit", DisplayMainMenu)
            };
            RunMenu(menuName, viewReportsMenuItems);
        }

        static void PersonReportMenu()
        {
            string menuName = "Person Report Menu";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void ProjectReportMenu()
        {
            string menuName = "Project Report Menu";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void TimeEntryReportMenu()
        {
            string menuName = "Time Entry Report Menu";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("\n\tThank you for using the App. We look forward to your next visit!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        static void GoBackMenuOption()
        {
            Console.WriteLine("\n\tPress ENTER to go back.\n");
            Console.ReadLine();
        }
    }
}