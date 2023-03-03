using static System.Console;

namespace TimeTrackeConsoleApp
{
    public class MenuSystem
    {
        public string? MenuItemText { get; set; }
        public Action? Action { get; set; } //to hold and be executed when menu item selected

        public MenuSystem(string? menuItemText, Action? action)
        {
            MenuItemText = menuItemText;
            Action = action;
        }
        private static void DisplayMenuItems(string menuName, List<MenuSystem> menuItems, int menuIndex)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("\n\tUse arrow keys to navigate and press Enter to select.");
            WriteLine("\tPlease select one of the following options:\n");
            ResetColor();
            WriteLine($"\t {menuName.ToUpper()}:");
            int maxIndexToSelect = menuItems.Count;
            for (int i = 0; i < maxIndexToSelect; i++)
            {
                if (i == menuIndex - 1)
                {
                    ForegroundColor = ConsoleColor.DarkYellow;
                }
                Write($"\n\t {i + 1}. {menuItems[i].MenuItemText}");
                ResetColor();
            }
        }

        private static int SelectMenuItemWithArrows(ConsoleKeyInfo keyInfo, int currentSelectionIndex, List<MenuSystem> menuItems)
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

        public static void RunMenu(string menuName, List<MenuSystem> menuItems)
        {
            bool runMenu = true;
            ConsoleKeyInfo keyInfo;
            int menuIndex = 1;

            while (runMenu)
            {
                Clear();
                DisplayMenuItems(menuName, menuItems, menuIndex);
                keyInfo = ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    MenuSystem selectedMenuItem = menuItems[menuIndex - 1];
                    // Invoke the corresponding method
                    Clear();
                    selectedMenuItem.Action?.Invoke();
                    WriteLine("\n\tPress any key to continue...");
                    ReadKey();
                }
                else
                {
                    menuIndex = SelectMenuItemWithArrows(keyInfo, menuIndex, menuItems);
                }
            }
        }
    }
}
