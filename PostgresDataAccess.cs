using Dapper;
using Npgsql;
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

        // TODO: Create "person"
        // TODO: Retrieve "person" by name
        // TODO: Retrieve a list with all "person"
        // TODO: Update "person"
        // TODO: Delete "person" by name

        // TODO: Create a project
        // TODO: Retrieve project by name
        // TODO: Retrieve a list with all projects
        // TODO: Update a project
        // TODO: Delete a project by name

        // TODO: Create a timeEntry
        // TODO: Retrieve a list of timeEntry per project name
        // TODO: Retrieve a list of timeEntry per "person" name
        // TODO: Update a timeEntry
        // TODO: Delete a timeEntry by person name
    }
}
