using Npgsql.Replication.PgOutput.Messages;

namespace TimeTrackeConsoleApp
{
    internal class PersonData
    {
        public int id { get; set; }
        public string? person_name { get; set; }

        public static void AddPerson()
        {
            Program.BannerMessageScreen();
            try
            {
                Console.Write("\n\tEnter username (UNIQUE): ");
                string? personName = Console.ReadLine();
                if (string.IsNullOrEmpty(personName))
                {
                    Console.WriteLine($"\n\tError: It's not a valid Name.\n");
                    return;
                }
                else
                {
                    PersonData person = new()
                    {
                        person_name = personName?.ToLower(),
                    };
                    PostgresDataAccess.CreateNewPersonData(person);
                    Console.WriteLine($"\tNew person successfully added: {personName}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError: The provided name is either already in use\n" +
                    $"\tor exceeds the maximum length of 25 characters.\n" +
                    $"\t{ex.Message}");
                Console.ResetColor();
            }
        }

        public static void UpdatePerson()
        {
            Program.BannerMessageScreen();
            try
            {
                Console.Write("\n\tEnter username you want to update: ");
                string? oldPersonName = Console.ReadLine()?.ToLower();
                Console.Write("\n\tEnter the new username: ");
                string? newPersonName = Console.ReadLine();
                if (string.IsNullOrEmpty(oldPersonName) || string.IsNullOrEmpty(newPersonName))
                {
                    Console.WriteLine($"\n\tError: It's not a valid Name.\n");
                    return;
                }
                else
                {
                    PostgresDataAccess.UpdatePersonData(oldPersonName, newPersonName.ToLower());
                    Console.WriteLine($"\tPerson successfully updated: {oldPersonName} now is {newPersonName}.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\tError: The provided name is either already in use\n" +
                    $"\tor exceeds the maximum length of 25 characters.\n" +
                    $"\t{ex.Message}");
                Console.ResetColor();
            }
        }

        public static void DisplayAllPersons()
        {
            Program.BannerMessageScreen();
            List<PersonData> listPersons = PostgresDataAccess.GetListAllPersons();
            if (listPersons?.Count > 0)
            {
                Console.WriteLine($"\n\t{listPersons.Count} users found:".ToUpper());
                int listIndex = listPersons.Count;
                for (int i = 0; i < listIndex; i++)
                {
                    string? personName = listPersons[i].person_name;

                    //Display List
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"\n\t {i + 1}. {personName}\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("No persons found");
            }
        }

        public static void DisplayPersonByProject()
        {
            Program.BannerMessageScreen();
            Console.Write("\n\tEnter Project Name: ");
            string? projectName = Console.ReadLine();
            List<PersonData> listPersons = PostgresDataAccess.GetListPersonByProject(projectName?.ToLower());

            if (listPersons?.Count > 0)
            {
                List<string> uniqueListNames = new List<string>(); //to remove duplicates
                int index = 1;
                Console.WriteLine($"\n\tusers in {projectName}'s project:".ToUpper());

                for (int i = 0; i < listPersons.Count; i++)
                {
                    string? personName = listPersons[i].person_name;

                    if (personName != null && !uniqueListNames.Contains(personName))
                    {
                        uniqueListNames.Add(personName);

                        //Display List
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"\n\t {index}. {personName}\n");
                        Console.ResetColor();

                        index++;
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\tNo persons found");
            }
        }

        public static string? GetPersonFromDB()
        {
            Console.Write("\n\tEnter Person Name: ");
            string? personName = Console.ReadLine();
            // Get person data from database
            PersonData getPerson = PostgresDataAccess.GetPersonDataByName(personName?.ToLower());
            return personName;
        }
    }
}
