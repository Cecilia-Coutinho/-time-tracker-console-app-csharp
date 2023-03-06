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
            Program.BannerMessageScreen();
            try
            {
                Console.Write("\n\tEnter project name you want to update: ");
                string? oldProjectName = Console.ReadLine()?.ToLower();
                Console.Write("\n\tEnter the new project name: ");
                string? newProjectName = Console.ReadLine();
                if (string.IsNullOrEmpty(oldProjectName) || string.IsNullOrEmpty(newProjectName))
                {
                    Console.WriteLine($"\n\tError: It's not a valid Project.\n");
                    return;
                }
                else
                {
                    PostgresDataAccess.UpdatePersonData(oldProjectName, newProjectName.ToLower());
                    Console.WriteLine($"\tProject successfully updated: {oldProjectName} now is {newProjectName}.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError: The provided project name is either already in use\n" +
                    $"\tor exceeds the maximum length of 25 characters.\n" +
                    $"\t{ex.Message}");
                Console.ResetColor();
            }
        }

        public static void DisplayAllProjects()
        {
            Program.BannerMessageScreen();
            List<ProjectData> listProjects = PostgresDataAccess.GetListAllProjects();
            if (listProjects?.Count > 0)
            {
                Console.WriteLine($"\n\t{listProjects.Count} projects found:".ToUpper());
                int listIndex = listProjects.Count;
                for (int i = 0; i < listIndex; i++)
                {
                    string? projectName = listProjects[i].project_name;

                    //Display List
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"\n\t {i + 1}. {projectName}\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("No persons found");
            }
        }

        public static void DisplayProjectByPerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
