using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MissionScheduler
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        // Method to add a new task
        public void AddTask()
        {
            Console.Write("Enter task name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter deadline (yyyy-MM-dd): ");
            DateTime deadline;
            while (!DateTime.TryParse(Console.ReadLine(), out deadline))
            {
                Console.Write("Invalid date. Please enter deadline (yyyy-MM-dd): ");
            }

            Console.Write("Enter priority (1-5): ");
            int priority;
            while (!int.TryParse(Console.ReadLine(), out priority) || priority < 1 || priority > 5)
            {
                Console.Write("Invalid priority. Please enter a number between 1 and 5: ");
            }

            Console.Write("Enter mission phase: ");
            string missionPhase = Console.ReadLine() ?? string.Empty;

            string criticalityLevel = GetValidatedInput(
                "Enter criticality level (Low/Medium/High): ",
                input => input.Equals("Low", StringComparison.OrdinalIgnoreCase) ||
                         input.Equals("Medium", StringComparison.OrdinalIgnoreCase) ||
                         input.Equals("High", StringComparison.OrdinalIgnoreCase),
                "Invalid input. Please enter Low, Medium, or High."
            );

            Console.Write("Enter dependency (name of the task this depends on, or leave blank): ");
            string dependency = Console.ReadLine() ?? string.Empty;

            tasks.Add(new Task(
                name: name,
                deadline: deadline,
                priority: priority,
                missionPhase: missionPhase,
                criticalityLevel: criticalityLevel,
                dependency: dependency
            ));

            Console.WriteLine("Task added successfully! Press Enter to continue.");
            Console.ReadLine();
        }

        // Method to view tasks
        public void ViewTasks()
        {
            Console.WriteLine("Sort tasks by:");
            Console.WriteLine("1. Priority");
            Console.WriteLine("2. Deadline");
            Console.WriteLine("3. Criticality Level");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? string.Empty;

            IEnumerable<Task> sortedTasks = choice switch
            {
                "1" => tasks.OrderBy(t => t.Priority),
                "2" => tasks.OrderBy(t => t.Deadline),
                "3" => tasks.OrderBy(t => t.CriticalityLevel),
                _ => tasks
            };

            Console.WriteLine("\n=== Task List ===");
            foreach (var task in sortedTasks)
            {
                Console.WriteLine(task);
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        // Method to save tasks to a file
        public void SaveTasks(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Tasks saved successfully! Press Enter to continue.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
            Console.ReadLine();
        }

        // Method to load tasks from a file
        public void LoadTasks(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    tasks = JsonConvert.DeserializeObject<List<Task>>(json) ?? new List<Task>();
                    Console.WriteLine("Tasks loaded successfully! Press Enter to continue.");
                }
                else
                {
                    Console.WriteLine("File not found. Press Enter to continue.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }
            Console.ReadLine();
        }

        // Method to adjust priorities near deadlines
        public void AdjustPriorities()
        {
            foreach (var task in tasks)
            {
                if ((task.Deadline - DateTime.Now).TotalDays <= 3 && task.Priority > 1)
                {
                    task.Priority--; // Escalate priority (lower value = higher priority)
                }
            }
            Console.WriteLine("Priorities adjusted based on deadlines. Press Enter to continue.");
            Console.ReadLine();
        }

        // Helper method for input validation
        private string GetValidatedInput(string prompt, Func<string, bool> validator, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;
                if (validator(input))
                {
                    return input;
                }
                Console.WriteLine(errorMessage);
            }
        }
    }
}