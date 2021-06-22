using System;
using System.Collections.Generic;

namespace TestingXUnit
{
    public class Timer
    {
        public List<TimeEntry> Entries { get; }
        private int LastEntryId { get; set; }

        public Timer()
        {
            Entries = new List<TimeEntry>();
            LastEntryId = 0;
        }

        public void Add(string client, string project, string note)
        {
            LastEntryId += 1;
            TimeEntry entry = new TimeEntry(LastEntryId, client, project, note);
            Entries.Add(entry);
        }

        public void Update(int entryId, TimeEntry entry)
        {
            Entries[entryId] =
                new TimeEntry(entryId, entry.Client, entry.Project, entry.Note, entry.Started, entry.Ended);
        }

        public void PrintEntries()
        {
            foreach (TimeEntry timeEntry in Entries)
            {
                Console.WriteLine($"{timeEntry.Client}, {timeEntry.Project}, {timeEntry.Note}");
            }
        }
    }
}