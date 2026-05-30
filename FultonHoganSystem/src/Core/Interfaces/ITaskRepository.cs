using Core.Models;
using System.Collections.Generic;
using Task = Core.Models.Task;

namespace Interfaces
{
    public interface ITaskRepository
    {
        // Saves the tasklist to the database
        void SaveTaskList(TaskList taskList);

        // Saves the task to the database
        void SaveTask(Task task);

        // Gets the tasklist from the database using its ID
        TaskList GetTaskListByID(string taskListID);

        // Gets a project's taskslists from the database using the project ID
        List<TaskList> GetProjectTaskLists(string projectID);

        // Gets the tasks of a list from the database using the tasklist ID
        List<Task> GetTasksByListID(string taskListID);
    }
}