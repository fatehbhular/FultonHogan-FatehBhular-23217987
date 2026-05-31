using Core.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using Task = Core.Models.Task;

namespace Services
{
    public class TaskService
    {
        private ITaskRepository TaskRepository;

        // This method creates the task service.
        public TaskService(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }

        // Verifies if the employee has permission to manage tasks
        // This method checks if the user can manage tasks.
        public bool VerifyEmployee(Employee employee)
        {
            string role = employee.GetRole();
            return role == "Project Coordinator" || role == "Site Lead";
        }

        // Creates a new list and saves it
        // This method creates and saves a task list.
        public TaskList CreateTaskList(string projectID, string description, Employee user)
        {
            if (!VerifyEmployee(user)) {
                Console.WriteLine("Access Denied: You do not have permission to create task lists.");
                return null;
            }

            string id = Guid.NewGuid().ToString().Substring(0, 8);
            TaskList newList = new TaskList(id, projectID, description);
            TaskRepository.SaveTaskList(newList);
            return newList;
        }

        // Adds a task to a list
        // This method adds a task to a task list and saves it.
        public void AddTaskToList(string taskListID, string description, Employee user)
        {
            if (!VerifyEmployee(user)) return;

            string taskID = "TSK-" + Guid.NewGuid().ToString().Substring(0, 5);
            Task newTask = new Task(taskID, taskListID, description, "Not Started");
            
            TaskRepository.SaveTask(newTask);
            Console.WriteLine($"Task added to list {taskListID} by {user.Name}");
        }

        // Updates status (e.g. Site Lead marking something as Completed)
        // This method changes a task status and saves it.
        public void UpdateTaskStatus(Task task, string newStatus, Employee user)
        {
            if (!VerifyEmployee(user)) return;

            task.ChangeStatus(newStatus);
            TaskRepository.SaveTask(task);
            Console.WriteLine($"Task {task.TaskID} updated to {newStatus} by {user.Name}");
        }
    }
}
