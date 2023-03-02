using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TimeTrackeConsoleApp
{
    public class MenuSystem
    {
        public string? MenuItemText { get; set; }
        //public List<string> MenuItems { get; set; }
        public int MenuIndex { get; set; }
        public Action? Action { get; set; } //to hold and be executed when menu item selected

        public MenuSystem(string? menuItemText, Action action)
        {
            MenuItemText = menuItemText;
            Action = action;
            MenuIndex = 0;
            //MenuItems = new List<string>();
        }
        public static void DisplayMenuItems(List<MenuSystem> menuItems, int menuIndex)
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(@"         ____________________ ");
            WriteLine(@"        |                    |");
            WriteLine(@"        |  TIME TRACKER APP  |");
            WriteLine(@"        |____________________|");
            ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\tUse arrow keys to navigate and press Enter to select.");
            Console.WriteLine("\tPlease select one of the following options:\n");
            Console.ResetColor();

            int maxIndexToSelect = menuItems.Count;
            for (int i = 0; i < maxIndexToSelect; i++)
            {
                if (i == menuIndex - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write($"\n\t {i + 1}. {menuItems[i].MenuItemText}");
                Console.ResetColor();
            }
        }

        public static int SelectMenuItemWithArrows(ConsoleKeyInfo keyInfo, int currentSelectionIndex, List<MenuSystem> menuItems)
        {
            int minIndexToSelect = 1;
            int maxIndexToSelect = menuItems.Count;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentSelectionIndex > minIndexToSelect)
                    {
                        currentSelectionIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSelectionIndex < maxIndexToSelect)
                    {
                        currentSelectionIndex++;
                    }
                    break;
            }
            return currentSelectionIndex;
        }
    }
}
