using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TimeTrackeConsoleApp
{
    internal class Helper
    {
        public static void TestCreatingNewPerson()
        {
            PersonData person = new PersonData()
            {
                person_name = "test",
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
                    Console.WriteLine($"Person Name: {person.person_name}");
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
                    Console.WriteLine($"Person Name: {person.person_name}");
                }
            }
            else
            {
                Console.WriteLine("No persons found");
            }
        }

        public static void TestUpdatePerson()
        {
            int rowsAffected = PostgresDataAccess.UpdatePerson("testperson", "test");
            Console.WriteLine($"{rowsAffected} rows updated");
        }

        public static void TestDeletePerson()
        {
            try
            {
                PersonData person = new PersonData()
                {
                    person_name = "test",
                };
                if (person.person_name != null)
                {
                    PostgresDataAccess.DeletePerson(person.person_name);
                    Console.WriteLine($"{person.person_name} deleted successfully!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestGetHoursByProjectName(string projectName)
        {
            List<TimeEntryData> timeEntries = PostgresDataAccess.GetTimeByProjectName(projectName);
            foreach (var entry in timeEntries)
            {
                Console.WriteLine($"Project: {projectName} || Hours: {entry.hours}");
            }
        }

        public static void TestGetHoursByPersonName(string personName)
        {
            List<TimeEntryData> timeEntries = PostgresDataAccess.GetTimeByPersonName(personName);
            foreach (var entry in timeEntries)
            {
                Console.WriteLine($"Hours: {entry.hours}");
            }
        }

        public static void TestUpdateTimeEntry()
        {
            TimeEntryData newEntry = new TimeEntryData()
            {
                hours = 5,
                date = ParseStringToDate("28-02-2023")
            };

            PostgresDataAccess.UpdateTimeEntry(newEntry, "maria.rosa", "coding");
            Console.WriteLine($"Hours updated to: {newEntry.hours}  || Date updated to: {ParseDateToString(newEntry.date)}");
        }

        static DateTime ParseStringToDate(string dateString)
        {
            string dateFormat = "dd-MM-yyyy"; //expected date format
            return DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
        }

        static string ParseDateToString(DateTime date)
        {
            string dateFormat = "dd-MM-yyyy";
            string dateString = date.ToString(dateFormat);
            return dateString;
        }
    }
}
