using Dapper;
using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace TimeTrackeConsoleApp
{
    internal class PostgresDataAccess
    {
        // variable to store the connection string
        private static string connectionString = LoadConnectionString();

        private static string LoadConnectionString(string id = "Default")
        {
            // Return the connection string stored in the configuration file
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        // ###### Here starts CRUD operations ( Create, Read-retrieve, Update, and Delete) ######

        // Create "person"
        public static void CreateNewPerson(PersonData person)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO csrc_person (person_name) " +
                        "VALUES (@person_name)";

                    var parameters = new DynamicParameters(person); // Use parameterized queries to prevent SQL injection attacks to be treated as data and not executed as part of the query
                    connection.Execute(sql, parameters);
                }
                catch (NpgsqlException ex) // catch when a PostgreSQL-related error occurs
                {
                    throw new Exception("Ops! Something happened... Error creating person(PostgreSQL-related)", ex);
                }
                catch (Exception ex) //catch any type of exception, not just PostgreSQL-related ones
                {
                    throw new Exception("Ops! Something happened... Error creating person!", ex);
                }
            }

        }

        // Retrieve "person" by name
        public static PersonData GetPersonByName(string personName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM csrc_person WHERE person_name = @person_name";
                    return connection.QuerySingleOrDefault<PersonData>(sql, new { person_name = personName });
                }
                catch (NpgsqlException ex) // catch when a PostgreSQL-related error occurs
                {
                    throw new Exception("Ops! Something happened... Error getting person by name(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened...Error getting person by name", ex);
                }
            }
        }

        // Retrieve a list with all "person"
        public static List<PersonData> GetListAllPersons()
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM csrc_person";
                    return connection.Query<PersonData>(sql).ToList();
                }
                catch (NpgsqlException ex) // catch PostgreSQL-related error
                {
                    throw new Exception("Ops! Something happened... Error getting a list of person(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting a list of person", ex);
                }
            }

        }
        // Update "person"

        public static int UpdatePerson(string oldPersonName, string newPersonName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "UPDATE csrc_person SET " +
                        "person_name = @new_person_name " +
                        "WHERE person_name = @old_person_name";

                    var parameters = new { old_person_name = oldPersonName, new_person_name = newPersonName }; //creation of anonymous object properties and assigning values to them
                    int rowsAffected = connection.Execute(sql, parameters);

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Update failed. Please contact the support");
                    }
                    return rowsAffected;
                }
                catch (NpgsqlException ex) // catch PostgreSQL-related error
                {
                    throw new Exception("Ops! Something happened... Error updating person(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error updating person", ex);
                }
            }
        }
        // TODO: Delete "person" by name

        // TODO: Create a project
        //public static void CreateNewProject()
        //{
        //    using (IDbConnection connection = new NpgsqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //}
        // TODO: Retrieve project by name
        //public static ProjectData GetProjectByName(string projectName)
        //{
        //    using (IDbConnection connection = new NpgsqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            return connection.QuerySingleOrDefault<ProjectData>();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //}
        // TODO: Retrieve a list with all projects
        // TODO: Update a project
        // TODO: Delete a project by name

        // TODO: Create a timeEntry
        //public static void CreateNewTimeEntry()
        //{
        //    using (IDbConnection connection = new NpgsqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //}
        // TODO: Retrieve a list of timeEntry per project name
        // TODO: Retrieve a list of timeEntry per "person" name
        // TODO: Update a timeEntry
        // TODO: Delete a timeEntry by person name
    }
}
