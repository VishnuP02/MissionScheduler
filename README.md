# MissionScheduler

A simple console-based application designed to help manage and prioritize tasks for mission-critical projects. This project demonstrates essential software engineering principles, including task management, file operations, and user interaction in C#.

## Features

- **Add Tasks**: Create new tasks with details like name, deadline, priority, mission phase, criticality level, and dependencies.
- **View Tasks**: Sort and view tasks based on priority, deadline, or criticality level.
- **Save Tasks**: Persist tasks to a JSON file for future use.
- **Load Tasks**: Load previously saved tasks from a JSON file.
- **Adjust Priorities**: Automatically update priorities based on approaching deadlines.

## Getting Started

### Prerequisites

To run this project, you'll need:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6 or later)
- A text editor or IDE such as [Visual Studio Code](https://code.visualstudio.com/) or [IntelliJ IDEA](https://www.jetbrains.com/idea/)


### Cloning the Repository

```bash
git clone https://github.com/VishnuP02/MissionScheduler.git
cd MissionScheduler
```

### Running the Application

1. Open a terminal in the project directory.
2. Build the application:
   ```bash
   dotnet build
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Usage

- **Add a Task**: Enter task details such as name, deadline, priority, etc.
- **View Tasks**: Choose a sorting method (priority, deadline, or criticality level) and view tasks in the desired order.
- **Save Tasks**: Save all tasks to a JSON file for future use.
- **Load Tasks**: Load tasks from a previously saved JSON file.
- **Adjust Priorities**: Automatically adjust task priorities based on their deadlines.

## Project Structure

- **`Task.cs`**: Defines the Task class, including properties for task details like name, deadline, priority, and dependencies.
- **`TaskManager.cs`**: Manages the core functionality, such as adding, viewing, saving, loading tasks, and adjusting priorities.
- **`Program.cs`**: The entry point of the application, providing the user interface and menu-driven interaction.

## Example Output

```plaintext
=== Mission Scheduler ===
1. Add Task
2. View Tasks
3. Save Tasks to File
4. Load Tasks from File
5. Adjust Priorities
6. Exit
Choose an option: 1

Enter task name: Prepare Launch Systems
Enter deadline (yyyy-MM-dd): 2025-01-25
Enter priority (1-5): 2
Enter mission phase: Launch Preparation
Enter criticality level (Low/Medium/High): High
Enter dependency (name of the task this depends on, or leave blank): 
Task added successfully! Press Enter to continue.
```
