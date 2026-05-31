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

        public ManagementGroupView()
        {
            InitializeComponent();
        }

        public ManagementGroupView(IEmployee user)
        {
            InitializeComponent();
            _user = user;
            _projectRepo = new DatabaseProjectRepository();
            _taskRepo = new DatabaseTaskRepository();

            LoadProjects();
        }

        private void LoadProjects()
        {
            // Fetch all projects from DB and put them in the Sidebar list
            List<Project> allProjects = _projectRepo.GetAllProjects();
            ProjectListBox.ItemsSource = allProjects;
        }

        private void OnProjectSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectListBox.SelectedItem is Project selected)
            {
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

        private void OnModifyClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ProjectListBox.SelectedItem is Project selected && _user is Roles.ProjectManager pm)
            {
                pm.ModifyProject(selected.ProjectID, _projectRepo);
                LoadProjects(); // Refresh list to show 'Suspended'
            }
        }

        private void OnLogoutClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (TopLevel.GetTopLevel(this) is Shared.MainWindow window) window.NavigateToLogin();
        }
    }
}
