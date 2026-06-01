# Fulton Hogan Management System

This is a C# desktop application for a Fulton Hogan style project management system. It uses Avalonia for the GUI and SQLite for saving data.

The system demonstrates role-based access, project management, task management, reports, timesheets, login, factories, repositories, services, and the observer design pattern.

## Main Features

- Role-based login for Management, Finance, and Operations users.
- Project managers can create projects and manage project tasks.
- Project coordinators can create progress reports.
- Management roles can receive project update notifications through the observer pattern.
- Finance users can view reports, create financial reports, approve project budgets, and approve or verify reports.
- Operations users can view instructions, submit problem reports, and add/view timesheet entries.
- Reports, projects, tasks, employees, and timesheet entries are saved in SQLite.

## Technologies Used

- C#
- .NET 10
- Avalonia UI
- SQLite
- Repository pattern
- Factory pattern
- Observer pattern

## Project Structure

```text
src/
  Auth/              Login classes
  Core/              Interfaces and main models
  Database/          Database table setup
  Factories/         Employee and report factories
  GUI/               Avalonia GUI files
  Reports/           Report subclasses
  Repositories/      SQLite database repositories
  Roles/             Employee role classes
  Services/          Business logic services
  Tests/             Workflow self-tests
```

## How To Build

From the project folder, run:

```bash
dotnet build FultonHogan.csproj
```

## How To Run The GUI

From the project folder, run:

```bash
dotnet run --project FultonHogan.csproj
```

The app creates the database tables when it starts. It also adds sample data so the GUI has projects, tasks, reports, and users to show.

## Demo Logins

All demo accounts use the password:

```text
123
```

| Role | Email |
| --- | --- |
| Project Manager | alice@fh.com |
| Project Coordinator | chris@fh.com |
| Site Lead | lena@fh.com |
| Financial Controller | john@fh.com |
| Project Accountant | priya@fh.com |
| Auditor | amelia@fh.com |
| Heavy Machine Operator | dave@fh.com |
| Site Foreman | sam@fh.com |
| General Labourer | gia@fh.com |

## How To Run The Self-Tests

The project has a self-test mode that checks the main required workflows without opening the GUI.

Run:

```bash
dotnet run --project FultonHogan.csproj -- --self-test
```

The self-tests check that:

- A project manager can save a project and tasks.
- A project coordinator can create and save a progress report.
- Management roles receive observer notifications.
- Reports and timesheets save and load.
- A general labourer and heavy machine operator can save and view timesheet entries.
- A financial controller can view and approve reports.

Expected result:

```text
SELF TEST RESULTS
PASS: Project manager can save a project and tasks
PASS: Project coordinator can save a progress report
PASS: Management roles receive observer notifications
PASS: Reports and timesheets save and load
PASS: General labourer and heavy machine operator can save and view timesheets
PASS: Financial controller can see and approve reports
```

## Design Patterns Used

### Factory Pattern

Employee factories create employees based on their department and role. The report factory creates the correct report subclass.

### Repository Pattern

Database repository classes handle saving and loading data from SQLite. This keeps database code separate from the main role and service logic.

### Observer Pattern

Projects can notify subscribed management roles when the project status changes. Project Manager, Project Coordinator, and Site Lead can receive these updates.

## Notes

- The GUI is a simple working demonstration of the system rather than a full production application.
- Some GUI actions use sample data so the main workflows can be shown clearly.
- Running the app or self-tests may change `fultonhogan.db` because data is saved to SQLite.
- Build warnings may appear for package vulnerability notices from dependencies.
