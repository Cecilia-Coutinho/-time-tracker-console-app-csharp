namespace TimeTrackeConsoleApp
{
    internal class ProjectData
    {
        public int id { get; set; }
        public string? project_name { get; set; }

        public static void AddProject()
        {
            Program.BannerMessageScreen();
            try
            {
                Console.Write("\n\tEnter Project Name (UNIQUE): ");
                string? projectName = Console.ReadLine()?.ToLower();
                if (string.IsNullOrEmpty(projectName))
                {
                    Console.WriteLine($"\n\tError: It's not a valid Project Name.\n");
                    return;
                }
                else
                {
                    ProjectData project = new()
                    {
                        project_name = projectName.ToLower(),
                    };
                    PostgresDataAccess.CreateNewProjectData(project);
                    Console.WriteLine($"\tNew project successfully added: {projectName}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError: The provided project name is either already in use\n" +
                    $"\tor exceeds the maximum length of 100 characters.\n" +
                    $"\t{ex.Message}");
                Console.ResetColor();
            }
        }

        public static void UpdateProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void DisplayAllProjects()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }

        public static void DisplayProjectByPerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
