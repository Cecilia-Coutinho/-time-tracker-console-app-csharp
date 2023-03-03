using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;

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
        public static bool CreateNewPersonData(PersonData person)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO csrc_person (person_name) " +
                        "VALUES (@person_name)";

                    var parameters = new DynamicParameters(person); // to prevent SQL injection attacks that can be passed to the Dapper Query and Execute methods to be treated as data and not executed as part of the query
                    return Convert.ToBoolean(connection.Execute(sql, parameters));
                }
                catch (NpgsqlException ex) // catch when a PostgreSQL-related error occurs
                {
                    throw new Exception("Error creating person(PostgreSQL-related)", ex);
                }
                catch (Exception ex) //catch any type of exception, not just PostgreSQL-related ones
                {
                    throw new Exception("Ops! Something happened... Error creating person!", ex);
                }
            }
        }

        // Retrieve "person" by name
        public static PersonData GetPersonDataByName(string personName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM csrc_person WHERE person_name = @person_name";
                    return connection.QuerySingleOrDefault<PersonData>(sql, new { person_name = personName });
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error getting person by name(PostgreSQL-related)", ex);
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
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error getting a list of person(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting a list of person", ex);
                }
            }

        }

        // Update "person"
        public static int UpdatePersonData(string? oldPersonName, string newPersonName)
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
                        throw new Exception("Update failed, any rows affected.");
                    }
                    return rowsAffected;
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error updating person(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error updating person", ex);
                }
            }
        }

        // Delete "person" by name
        public static void DeletePersonData(string personName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "DELETE FROM csrc_person WHERE person_name = @person_name";
                    connection.Execute(sql, new { person_name = personName });
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error deleting user(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error deleting user", ex);
                }
            }
        }

        // Create a project
        public static bool CreateNewProjectData(ProjectData project)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO csrc_project (project_name) " +
                        "VALUES (@project_name)";

                    var parameters = new DynamicParameters(project);
                    return Convert.ToBoolean(connection.Execute(sql, parameters));
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error creating project(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error creating project!", ex);
                }
            }
        }

        // Retrieve project by name
        public static ProjectData GetProjectDataByName(string projectName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM csrc_project WHERE project_name = @project_name";
                    return connection.QuerySingleOrDefault<ProjectData>(sql, new { person_name = projectName });
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error getting project by name(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting project by name!", ex);
                }
            }
        }

        // Retrieve a list with all projects
        public static List<ProjectData> GetListAllProjects()
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM csrc_project";
                    return connection.Query<ProjectData>(sql).ToList();
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error getting a list of projects(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting a list of projects", ex);
                }
            }
        }

        // Update a project
        public static int UpdateProjectData(string oldProjectName, string newProjectName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "UPDATE csrc_project SET " +
                        "project_name = @new_project_name " +
                        "WHERE person_name = @old_project_name";

                    var parameters = new { old_project_name = oldProjectName, new_project_name = newProjectName };
                    int rowsAffected = connection.Execute(sql, parameters);

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Update failed, no rows affected.");
                    }
                    return rowsAffected;
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error updating project(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error updating project", ex);
                }
            }
        }

        // Delete a project by name
        public static void DeleteProjectData(string projectName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "DELETE FROM csrc_project WHERE project_name = @project_name";
                    connection.Execute(sql, new { project_name = projectName });
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error deleting project(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error deleting project", ex);
                }
            }
        }

        // Create a timeEntry
        public static void CreateNewTimeEntryData(TimeEntryData timeEntry)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction()) //using transaction because of foreign keys
                {
                    try
                    {
                        string sql = "INSERT INTO csrc_project_person (project_id, person_id, hours, date) " +
                        "VALUES (@project_id, @person_id, @hours, @date)";

                        var parameters = new DynamicParameters(timeEntry);
                        connection.Execute(sql, parameters, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (NpgsqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error creating hours(PostgreSQL-related)", ex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ops! Something happened... Error creating hours!", ex);
                    }
                }
            }
        }

        // Retrieve a list of timeEntry per project name
        public static List<TimeEntryData> GetTimeDataByProjectName(string projectName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT hours FROM csrc_project_person " +
                            "JOIN csrc_project ON csrc_project_person.project_id = csrc_project.id " +
                            "WHERE csrc_project.project_name = @project_name";

                    var parameters = new { project_name = projectName };
                    var listProjectHours = connection.Query<TimeEntryData>(sql, parameters).ToList();
                    return listProjectHours;
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error getting hours by project(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting hours by project!", ex);
                }
            }
        }

        // Retrieve a list of timeEntry per "person" name
        public static List<TimeEntryData> GetTimeDataByPersonName(string personName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT hours FROM csrc_project_person " +
                            "JOIN csrc_person ON csrc_project_person.person_id = csrc_person.id " +
                            "WHERE csrc_person.person_name = @person_name";

                    var parameters = new { person_name = personName };
                    var listPersonHours = connection.Query<TimeEntryData>(sql, parameters).ToList();
                    return listPersonHours;
                }
                catch (NpgsqlException ex)
                {
                    throw new Exception("Error getting hours by person name(PostgreSQL-related)", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ops! Something happened... Error getting hours by person name!", ex);
                }
            }
        }

        // Update a timeEntry by project and person name
        public static void UpdateTimeEntryData(TimeEntryData updateTimeEntry
            , string personName, string projectName)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE csrc_project_person SET hours = @hours, date = @date " +
                                     "FROM csrc_person, csrc_project " +
                                     "WHERE csrc_person.person_name = @person_name " +
                                     "AND csrc_project.project_name = @project_name " +
                                     "AND csrc_project_person.project_id = csrc_project.id " +
                                     "AND csrc_project_person.person_id = csrc_person.id";

                        var parameters = new
                        {
                            hours = updateTimeEntry.hours,
                            date = updateTimeEntry.date,
                            person_name = personName,
                            project_name = projectName
                        };
                        connection.Execute(sql, parameters, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (NpgsqlException ex)
                    {
                        throw new Exception("Error updating time entry(PostgreSQL-related)", ex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ops! Something happened... Error updating time entry", ex);
                    }
                }
            }
        }

        // TODO if needed:  Delete timeEntry by project and person name
    }
}
