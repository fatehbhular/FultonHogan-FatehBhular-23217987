using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Core.Models;
using Interfaces;
using Task = Core.Models.Task;

namespace Repositories
{
    public class DatabaseTaskRepository : ITaskRepository
    {
        private DatabaseConnection DbConnection;

        public DatabaseTaskRepository()
        {
            DbConnection = DatabaseConnection.GetInstance();
        }

        public void SaveTaskList(TaskList taskList)
        {
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();
            string sql = "INSERT OR REPLACE INTO TaskLists (TaskListID, ProjectID, Description) VALUES (@ID, @ProjID, @Desc)";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", taskList.TaskListID);
                cmd.Parameters.AddWithValue("@ProjID", taskList.ProjectID);
                cmd.Parameters.AddWithValue("@Desc", taskList.Description);
                cmd.ExecuteNonQuery();
            }

            // Also save all tasks currently in the list
            foreach (var task in taskList.IncludedTasks)
            {
                SaveTask(task);
            }
        }

        public void SaveTask(Task task)
        {
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();
            string sql = "INSERT OR REPLACE INTO Tasks (TaskID, TaskListID, Description, Status) VALUES (@ID, @ListID, @Desc, @Status)";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", task.TaskID);
                cmd.Parameters.AddWithValue("@ListID", task.TaskListID);
                cmd.Parameters.AddWithValue("@Desc", task.Description);
                cmd.Parameters.AddWithValue("@Status", task.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public TaskList GetTaskListByID(string taskListID)
        {
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();
            string sql = "SELECT * FROM TaskLists WHERE TaskListID = @ID";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", taskListID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var list = new TaskList(reader["TaskListID"].ToString(), reader["ProjectID"].ToString(), reader["Description"].ToString());
                        list.IncludedTasks = GetTasksByListID(taskListID);
                        return list;
                    }
                }
            }
            return null;
        }

        public List<Task> GetTasksByListID(string taskListID)
        {
            var tasks = new List<Task>();
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();
            string sql = "SELECT * FROM Tasks WHERE TaskListID = @ID ORDER BY RowID ASC";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", taskListID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Ensure null safety with .ToString() ?? ""
                        tasks.Add(new Task(
                            reader["TaskID"].ToString() ?? "",
                            reader["TaskListID"].ToString() ?? "",
                            reader["Description"].ToString() ?? "",
                            reader["Status"].ToString() ?? ""
                        ));
                    }
                }
            }
            return tasks;
        }

        public List<TaskList> GetProjectTaskLists(string projectID)
        {
            var lists = new List<TaskList>();
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();
            string sql = "SELECT * FROM TaskLists WHERE ProjectID = @ProjectID ORDER BY RowID ASC";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProjectID", projectID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var list = new TaskList(
                            reader["TaskListID"].ToString() ?? "",
                            reader["ProjectID"].ToString() ?? "",
                            reader["Description"].ToString() ?? ""
                        );
                        list.IncludedTasks = GetTasksByListID(list.TaskListID);
                        lists.Add(list);
                    }
                }
            }
            return lists;
        }
    }
}
