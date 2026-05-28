namespace Repositories
{
    public class DatabaseProjectRepository : IProjectRepository
    {
        private DatabaseConnection dbConnection;

        public DatabaseProjectRepository()
        {
            dbConnection = DatabaseConnection.GetInstance();
            dbConnection.Connect();
        }

        public void Save(Project project)
        {
            dbConnection.Connect();
            SqliteConnection connection = new dbConnection.GetConnect();

            string sql = @"INSERT OR REPLACE INTO Projects (ProjectID, Title, StartDate, Deadline, BudgetLimit, CurrentSpendings, Status) VALUES (@ProjectID, @Title, @StartDate, @Deadline, @BudgetLimit, @CurrentSpendings, @Status)";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ProjectID", project.ProjectID);
                command.Parameters.AddWithValue("@Title", project.Title);

                command.Parameters.AddWithValue("@StartDate", project.StartDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Deadline", project.EndDate.ToString("yyyy-MM-dd"));

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

        public Project GetByID(string projectID)
        {
            dbConnection.Connect();
            SqliteConnection connection = dbConnection.GetConnect();

            string sql = @"SELECT * FROM Projects WHERE ProjectID = @ProjectID";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ProjectID", projectID);

                using (var reader = command.ExecuteReader()) {
                    if (rerader.Read())
                    {
                        string id = reader["ProjectID"].ToString();
                        string title = reader["Title"].ToString();

                        DateOnly startDate = DateOnly.Parse(reader["StartDate"].ToString());
                        DateOnly deadline = DateOnly.Parse(reader["Deadline"].ToString());
                        double budget = Convert.ToDouble(reader["BudgetLimit"]);

                        Project project = new Project(id, title, startDate, deadline, budget);

                        project.CurrentSpendings = Convert.ToDouble(reader["CurrentSpendings"]);
                        project.Status = reader["Status"].ToString();

                        return project;
                    }
                }
            }

            return null;
        }
    }
}