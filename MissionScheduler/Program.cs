using System;

namespace MissionScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Mission Scheduler ===");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Save Tasks to File");
                Console.WriteLine("4. Load Tasks from File");
                Console.WriteLine("5. Adjust Priorities");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        taskManager.AddTask();
                        break;
                    case "2":
                        taskManager.ViewTasks();
                        break;
                    case "3":
                        taskManager.SaveTasks("tasks.json");
                        break;
                    case "4":
                        taskManager.LoadTasks("tasks.json");
                        break;
                    case "5":
                        taskManager.AdjustPriorities();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}