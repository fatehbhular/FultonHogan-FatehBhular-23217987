using Avalonia.Controls;
using Core.Models;
using Core.Interfaces;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using Task = Core.Models.Task;
using Avalonia.Interactivity;

namespace GUI.Views.RoleViews
{
    public partial class ManagementGroupView : UserControl
    {
        private IEmployee _user;
        private DatabaseProjectRepository _projectRepo;
        private DatabaseTaskRepository _taskRepo;
        private Project _selectedProject;

        // This method creates the view for the designer.
        public ManagementGroupView()
        {
            InitializeComponent();
        }

        // This method creates the management view for the logged in user.
        public ManagementGroupView(IEmployee user)
        {
            InitializeComponent();
            _user = user;
            _projectRepo = new DatabaseProjectRepository();
            _taskRepo = new DatabaseTaskRepository();

            LoadProjects();
        }

        // This method loads projects from the database.
        private void LoadProjects()
        {
            // Fetch all projects from DB and put them in the Sidebar list
            List<Project> allProjects = _projectRepo.GetAllProjects();
            ProjectListBox.ItemsSource = allProjects;
        }

        // This method shows the selected project and its tasks.
        private void OnProjectSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectListBox.SelectedItem is Project selected)
            {
                _selectedProject = selected;
                // Shows the panel
                ProjectDetailsPanel.IsVisible = true;

                // Filsl the details from the Project
                SelectedProjectTitle.Text = selected.Title;
                SelectedProjectStatus.Text = selected.Status;
                TxtDeadline.Text = selected.Deadline.ToString("MMMM dd, yyyy");
                TxtBudget.Text = $"${selected.BudgetLimit:N0}";
                TxtSpend.Text = $"${selected.CurrentSpendings:N0}";

                // Load all task lists for the selected project and flatten them for display.
                var tasks = _taskRepo.GetProjectTaskLists(selected.ProjectID)
                    .SelectMany(list => list.IncludedTasks)
                    .ToList();
                TaskDetailsList.ItemsSource = tasks;
                ActionLog.Text = $"Loaded {tasks.Count} tasks for {selected.Title}.";
            }
        }

        // This method creates a new project and saves it.
        private void OnAddProjectClick(object sender, RoutedEventArgs e)
        {
            // Generate unique ID
            string newID = "PROJ-" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            
            // Create new project with default values
            Project newProj = new Project(
                newID, 
                "New Infrastructure Project", 
                DateOnly.FromDateTime(DateTime.Now), 
                DateOnly.FromDateTime(DateTime.Now.AddMonths(1)), 
                20000
            );
            
            _projectRepo.Save(newProj);
            
            // Refresh the Sidebar List
            LoadProjects();
            
            // Log action to the UI
            ActionLog.Text = $"Created new project: {newID}";
        }

        // This method changes the selected project and saves it.
        private void OnModifyClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ProjectListBox.SelectedItem is Project selected && _user is Roles.ProjectManager pm)
            {
                pm.ModifyProject(selected.ProjectID, _projectRepo);
                LoadProjects(); // Refresh list to show 'Suspended'
                ActionLog.Text = $"Updated project {selected.ProjectID}.";
            }
        }

        // This method adds a task to the selected project and saves it.
        private void OnAddTaskClick(object sender, RoutedEventArgs e)
        {
            if (_selectedProject == null) return;

            string description = NewTaskInput.Text?.Trim() ?? "";
            if (description.Length == 0)
            {
                ActionLog.Text = "Enter a task description first.";
                return;
            }

            string listID = $"TL-{_selectedProject.ProjectID}-GUI";
            var taskList = _taskRepo.GetTaskListByID(listID) ?? new TaskList(listID, _selectedProject.ProjectID, "Management task list");
            var task = new Task($"TASK-{Guid.NewGuid().ToString()[..8].ToUpper()}", listID, description, "Not Started");
            taskList.AddTask(task);
            _taskRepo.SaveTaskList(taskList);
            NewTaskInput.Text = "";
            RefreshSelectedProjectTasks();
            ActionLog.Text = $"Added task to {_selectedProject.Title}.";
        }

        // This method marks the selected task as complete and saves it.
        private void OnCompleteTaskClick(object sender, RoutedEventArgs e)
        {
            if (TaskDetailsList.SelectedItem is Task task)
            {
                task.ChangeStatus("Completed");
                _taskRepo.SaveTask(task);
                RefreshSelectedProjectTasks();
                ActionLog.Text = $"Completed task {task.TaskID}.";
            }
        }

        // This method reloads the tasks for the selected project.
        private void RefreshSelectedProjectTasks()
        {
            if (_selectedProject == null) return;

            var tasks = _taskRepo.GetProjectTaskLists(_selectedProject.ProjectID)
                .SelectMany(list => list.IncludedTasks)
                .ToList();
            TaskDetailsList.ItemsSource = tasks;
        }

        // This method logs the user out and shows the login page.
        private void OnLogoutClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (TopLevel.GetTopLevel(this) is Shared.MainWindow window) window.NavigateToLogin();
        }
    }
}
