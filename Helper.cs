using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackeConsoleApp
{
    internal class Helper
    {
        public static void TestCreatingNewPerson()
        {
            PersonData person = new PersonData()
            {
                person_name = "testperson",
            };
            PostgresDataAccess.CreateNewPerson(person);
            Console.WriteLine($"New Person: {person.person_name}");
        }

        public static void TestGettingPersonByName()
        {
            try
            {
                PersonData personName = new PersonData()
                {
                    person_name = "testperson"
                };

                PersonData person = PostgresDataAccess.GetPersonByName(personName.person_name);
                if (person != null)
                {
                    Console.WriteLine($"Person ID: {person.id} || Person Name: {person.person_name}");
                }
                else
                {
                    Console.WriteLine("Doesn't exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void TestGetListAllPerson()
        {
            List<PersonData> listPerson = PostgresDataAccess.GetListAllPersons();
            if (listPerson != null && listPerson.Count > 0)
            {
                Console.WriteLine($"Retrieved {listPerson.Count} users:");
                foreach (PersonData person in listPerson)
                {
                    Console.WriteLine($"Person ID: {person.id} || Person Name: {person.person_name}");
                }
            }
            else
            {
                Console.WriteLine("No persons found");
            }
        }

        public static void TestUpdateUser()
        {
            int rowsAffected = PostgresDataAccess.UpdatePerson("Test", "testperson");
            Console.WriteLine($"{rowsAffected} rows updated");
        }
    }
}
