using System;
using Microsoft.Data.Sqlite;
using Core.Interfaces;
using Core.Models;

namespace Repositories
{
    // Implementation of IProjectRepo
    public class DatabaseProjectRepository : IProjectRepository
    {
        // Field that 
        private DatabaseConnection DbConnection;

        // This method creates the project repository.
        public DatabaseProjectRepository()
        {
            DbConnection = DatabaseConnection.GetInstance();
        }

        // This method saves a project.
        public void Save(Project project)
        {
            // Ensure the connection is open
            DbConnection.Connect();
            SqliteConnection connection = DbConnection.GetConnect();

            string sql = @"INSERT OR REPLACE INTO Projects (ProjectID, Title, StartDate, Deadline, BudgetLimit, CurrentSpendings, Status) VALUES (@ProjectID, @Title, @StartDate, @Deadline, @BudgetLimit, @CurrentSpendings, @Status)";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ProjectID", project.ProjectID);
                command.Parameters.AddWithValue("@Title", project.Title);

                command.Parameters.AddWithValue("@StartDate", project.StartDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Deadline", project.Deadline.ToString("yyyy-MM-dd"));

                command.Parameters.AddWithValue("@BudgetLimit", project.BudgetLimit);
                command.Parameters.AddWithValue("@CurrentSpendings", project.CurrentSpendings);
                command.Parameters.AddWithValue("@Status", project.Status);

                try {
                    command.ExecuteNonQuery();
                } catch (SqliteException ex) {
                    Console.WriteLine($"Database error saving project: {ex.Message}");
                    throw;
                }
            }
        }

        // This method gets a project by its ID.
        public Project GetByID(string projectID)
        {
            DbConnection.Connect();
            SqliteConnection connection = DbConnection.GetConnect();

            string sql = @"SELECT * FROM Projects WHERE ProjectID = @ProjectID";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ProjectID", projectID);

                using (var reader = command.ExecuteReader()) {
                    if (reader.Read())
                    {
                        string id = reader["ProjectID"].ToString() ?? "";
                        string title = reader["Title"].ToString() ?? "";

                        DateOnly startDate = DateOnly.Parse(reader["StartDate"].ToString() ?? DateTime.Now.ToString("yyyy-MM-dd"));
                        DateOnly deadline = DateOnly.Parse(reader["Deadline"].ToString() ?? DateTime.Now.ToString("yyyy-MM-dd"));

                        int budget = (int)Convert.ToDouble(reader["BudgetLimit"]);

                        Project project = new Project(id, title, startDate, deadline, budget);

                        project.CurrentSpendings = (int)Convert.ToDouble(reader["CurrentSpendings"]);
                        project.Status = reader["Status"].ToString() ?? "Planned";

                        return project;
                    }
                }
            }

            return null;
        }

        // This method gets all projects.
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();
            string sql = "SELECT * FROM Projects";

            using (var cmd = new SqliteCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var p = new Project(
                        reader["ProjectID"].ToString() ?? "",
                        reader["Title"].ToString() ?? "",
                        DateOnly.Parse(reader["StartDate"].ToString() ?? ""),
                        DateOnly.Parse(reader["Deadline"].ToString() ?? ""),
                        (int)Convert.ToDouble(reader["BudgetLimit"])
                    );
                    p.Status = reader["Status"].ToString() ?? "";
                    p.CurrentSpendings = (int)Convert.ToDouble(reader["CurrentSpendings"]);
                    projects.Add(p);
                }
            }
            return projects;
        }
    }
}
