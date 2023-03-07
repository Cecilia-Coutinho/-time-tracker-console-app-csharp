namespace TimeTrackeConsoleApp
{
    internal class ProjectData
    {
        public int id { get; set; }
        public string? project_name { get; set; }

        public static void AddProject()
        {
            Program.BannerMessageScreen();

            Console.Write("\n\tEnter Project Name (UNIQUE): ");
            string? projectName = Console.ReadLine();

            if (string.IsNullOrEmpty(projectName))
            {
                Console.WriteLine($"\n\tError: It's not a valid Project Name.\n");
                return;
            }

            try
            {
                ProjectData project = new()
                {
                    project_name = projectName.ToLower(),
                };
                PostgresDataAccess.CreateNewProjectData(project);
                Console.WriteLine($"\tNew project successfully added: {projectName}");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError: The provided project name is either already in use\n" +
                    $"\tor exceeds the maximum length of 100 characters.");
                Console.ResetColor();
            }
        }

        public static void UpdateProject()
        {
            Program.BannerMessageScreen();

            Console.Write("\n\tEnter project name you want to update: ");
            string? oldProjectName = Console.ReadLine();
            Console.Write("\n\tEnter the new project name: ");
            string? newProjectName = Console.ReadLine();

            if (string.IsNullOrEmpty(oldProjectName) || string.IsNullOrEmpty(newProjectName))
            {
                Console.WriteLine($"\n\tError: It's not a valid Project.\n");
                return;
            }

            try
            {
                PostgresDataAccess.UpdateProjectData(oldProjectName.ToLower(), newProjectName.ToLower());
                Console.WriteLine($"\tProject successfully updated: {oldProjectName.ToLower()} now is {newProjectName.ToLower()}.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError! Please check your data and try again." +
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

        public static void DisplayProjectsListByPerson()
        {
            Program.BannerMessageScreen();
            Console.Write("\n\tEnter Person Name: ");
            string? personName = Console.ReadLine();
            List<ProjectData> listPersons = PostgresDataAccess.GetListProjectByPerson(personName?.ToLower());

            if (listPersons?.Count > 0)
            {
                List<string> uniqueListNames = new List<string>(); //to remove duplicates
                int index = 1;

                //display title
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n\tProjects associated with {personName}:".ToUpper());
                Console.ResetColor();

                for (int i = 0; i < listPersons.Count; i++)
                {
                    string? projectName = listPersons[i].project_name;

                    if (projectName != null && !uniqueListNames.Contains(projectName))
                    {
                        uniqueListNames.Add(projectName);

                        //Display List
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"\n\t {index}. {projectName}\n");
                        Console.ResetColor();

                        index++;
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\tNo projects found");
            }
        }

        public static string? GetProjectFromDB()
        {
            Console.Write("\n\tEnter Project Name: ");
            string? projectName = Console.ReadLine();
            // Get person data from database
            ProjectData getProject = PostgresDataAccess.GetProjectDataByName(projectName?.ToLower());
            return projectName;
        }
    }
}
