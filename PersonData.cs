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
                string? personName = Console.ReadLine()?.ToLower();
                if (string.IsNullOrEmpty(personName))
                {
                    Console.WriteLine($"\n\tError: It's not a valid Name.\n");
                    return;
                }
                else
                {
                    PersonData person = new()
                    {
                        person_name = personName,
                    };
                    PostgresDataAccess.CreateNewPersonData(person);
                    Console.WriteLine($"\tNew person successfully added: {person.person_name}");
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
                Console.Write("\n\tEnter username you want update: ");
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
            List<PersonData> listPersons = PostgresDataAccess.GetListAllPersons();
            if (listPersons?.Count > 0)
            {
                //Console.WriteLine($"Retrieved {listPersons.Count} users:");
                string menuName = $"{listPersons.Count} users found";
                List<MenuSystem> personToSelect = new();
                foreach (PersonData person in listPersons)
                {
                    //Console.WriteLine($"Person Name: {person.person_name}");
                    personToSelect.Add(new MenuSystem($"{person.person_name}", () => Console.WriteLine($"")));
                }
                Program.BannerMessageScreen();
                MenuSystem.RunMenu(menuName, personToSelect);
            }
            else
            {
                Console.WriteLine("No persons found");
            }

        }

        public static void DisplayPersonByProject()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("coming soon");
            Console.ResetColor();
        }
    }
}
