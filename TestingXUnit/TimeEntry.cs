using System;

namespace TestingXUnit
{
    public class TimeEntry
    {
        public int Id { get; private set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Note { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }

        public TimeEntry(int id, string client, string project, string note)
        {
            Id = id;
            Client = client;
            Project = project;
            Note = note;
            Started = DateTime.Now;
            Ended = DateTime.MaxValue;
        }
        public TimeEntry(string client, string project, string note)
        {
            Client = client;
            Project = project;
            Note = note;
            Started = DateTime.Now;
            Ended = DateTime.MaxValue;
        }
        
        public TimeEntry(int id,string client, string project, string note, DateTime started, DateTime ended)
        {
            Id = id;
            Client = client;
            Project = project;
            Note = note;
            Started = started;
            Ended = ended;
        }

        public bool End()
        {
            Ended = DateTime.Now;
            return true;
        }

        public string ElapsedTime()
        {
            TimeSpan diff = Ended.Subtract(Started);
            return $"{diff.Days} days, {diff.Hours} hours, {diff.Minutes} minute(s)";
        }
    }
}