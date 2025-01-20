using System;

namespace MissionScheduler
{
    public class Task
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public string MissionPhase { get; set; }
        public string CriticalityLevel { get; set; }
        public string Dependency { get; set; } // New property for task dependencies

        public Task(string name, DateTime deadline, int priority, string missionPhase, string criticalityLevel, string dependency = "")
        {
            Name = name;
            Deadline = deadline;
            Priority = priority;
            MissionPhase = missionPhase;
            CriticalityLevel = criticalityLevel;
            Dependency = dependency;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Deadline: {Deadline:yyyy-MM-dd}, Priority: {Priority}, Phase: {MissionPhase}, Criticality: {CriticalityLevel}, Dependency: {Dependency}";
        }
    }
}