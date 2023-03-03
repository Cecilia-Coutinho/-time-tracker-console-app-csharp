using System.ComponentModel;
using static System.Console;
using static TimeTrackeConsoleApp.MenuSystem;

namespace TimeTrackeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

        public static void BannerMessageScreen()
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(@"         ____________________ ");
            WriteLine(@"        |                    |");
            WriteLine(@"        |  TIME TRACKER APP  |");
            WriteLine(@"        |____________________|");
            ResetColor();
        }

        static void DisplayMainMenu()
        {
            Thread.Sleep(20);
            string menuName = "Main Menu";
            List<MenuSystem> mainMenuItems = new()
            {
                new MenuSystem("Manage Person", ManagePersonMenu),
                new MenuSystem("Manage Project", ManageProjectMenu),
                new MenuSystem("Manage Time Entry", ManageTimeEntryMenu),
                new MenuSystem("View Reports", ViewReportsMenu),
                new MenuSystem("Exit", Exit)
            };
            BannerMessageScreen();
            RunMenu(menuName, mainMenuItems);
        }

        public static void ManagePersonMenu()
        {
            string menuName = "Manage Person Menu";
            List<MenuSystem> managePersonMenuItems = new()
            {
                new MenuSystem("Create New Person", PersonData.AddPerson),
                new MenuSystem("Edit Person", PersonData.UpdatePerson),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, managePersonMenuItems);
        }

        static void ManageProjectMenu()
        {
            string menuName = "Manage Project Menu";
            List<MenuSystem> manageProjectMenuItems = new()
            {
                new MenuSystem("Create New Project", ProjectData.AddProject),
                new MenuSystem("Edit Project", ProjectData.UpdateProject),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, manageProjectMenuItems);
        }

        static void ManageTimeEntryMenu()
        {
            string menuName = "Manage Time Entry Menu";
            List<MenuSystem> manageTimeEntryMenuItems = new()
            {
                new MenuSystem("Create Time Entry", TimeEntryData.CreateTimeEntry),
                new MenuSystem("Edit Time Entry", TimeEntryData.UpdateTimeEntry),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, manageTimeEntryMenuItems);
        }

        static void ViewReportsMenu()
        {
            string menuName = "View Report Menu";
            List<MenuSystem> viewReportsMenuItems = new()
            {
                new MenuSystem("View Persons Report", PersonReportMenu),
                new MenuSystem("View Projects Report", ProjectReportMenu),
                new MenuSystem("View Time Entries Report", TimeEntryReportMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, viewReportsMenuItems);
        }

        static void PersonReportMenu()
        {
            string menuName = "Person Report Menu";

            List<MenuSystem> PersonReportsMenuItems = new()
            {
                new MenuSystem("Display All Persons", PersonData.DisplayAllPersons),
                new MenuSystem("Display Persons By Project", DisplayPersonByProjectMenu),
                new MenuSystem("Return to Previous Menu", ViewReportsMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, PersonReportsMenuItems);
        }

        static void ProjectReportMenu()
        {
            string menuName = "Project Report Menu";

            List<MenuSystem> ProjectReportsMenuItems = new()
            {
                new MenuSystem("Display All Projects", ProjectData.DisplayAllProjects),
                new MenuSystem("Display Projects By Person", DisplayProjectByPersonMenu),
                new MenuSystem("Return to Previous Menu", ViewReportsMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, ProjectReportsMenuItems);
        }

        static void TimeEntryReportMenu()
        {
            string menuName = "Time Entry Report Menu";
            List<MenuSystem> TimeEntryReportsMenuItems = new()
            {
                new MenuSystem("Display All Time Entries By Person", DisplayTimeEntriesByPersonMenu),
                new MenuSystem("Display All Time Entries By Project", DisplayTimeEntriesByProjectMenu),
                new MenuSystem("Return to Previous Menu", ViewReportsMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, TimeEntryReportsMenuItems);
        }

        static void DisplayPersonByProjectMenu()
        {
            string menuName = "Person By Project Report Menu";
            List<MenuSystem> displayPersonByProjectMenuItems = new()
            {
                new MenuSystem("Select Project", PersonData.DisplayPersonByProject),
                new MenuSystem("Return to Previous Menu", PersonReportMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, displayPersonByProjectMenuItems);
        }

        static void DisplayProjectByPersonMenu()
        {
            string menuName = "Project By Person Report Menu";
            List<MenuSystem> displayProjectByPersonMenuItems = new()
            {
                new MenuSystem("Select Person", ProjectData.DisplayProjectByPerson),
                new MenuSystem("Return to Previous Menu", ProjectReportMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, displayProjectByPersonMenuItems);
        }

        static void DisplayTimeEntriesByPersonMenu()
        {
            string menuName = "Time Entries By Person Report Menu";
            List<MenuSystem> displayTimeEntriesByPersonMenuItems = new()
            {
                new MenuSystem("Select Person", TimeEntryData.DisplayAllTimeEntriesByPerson),
                new MenuSystem("Return to Previous Menu", TimeEntryReportMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, displayTimeEntriesByPersonMenuItems);
        }

        static void DisplayTimeEntriesByProjectMenu()
        {
            string menuName = "Time Entries By Project Report Menu";
            List<MenuSystem> displayTimeEntriesByProjectMenuItems = new()
            {
                new MenuSystem("Select Project", TimeEntryData.DisplayAllTimeEntriesByProject),
                new MenuSystem("Return to Previous Menu", TimeEntryReportMenu),
                new MenuSystem("Return to Main Menu", DisplayMainMenu)
            };
            BannerMessageScreen();
            RunMenu(menuName, displayTimeEntriesByProjectMenuItems);
        }
        static void Exit()
        {
            Clear();
            WriteLine("\n\tThank you for using the App. We look forward to your next visit!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}