using System;
using System.IO;
using Xunit;

namespace TestingXUnit.Tests
{
    public class TimerTests
    {
        [Fact]
        public void Add_CreatesATimeEntry()
        {
            Timer timer = new Timer();
            timer.Add("Test Client", "Test Project", "");
            
            Assert.Equal(1, (int) timer.Entries.Count);
            Assert.Equal("Test Client", timer.Entries[0].Client);
            Assert.Equal(DateTime.Now, timer.Entries[0].Started, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void Update_ChangesThePropertiesOfAnExistingEntry()
        {
            Timer timer = new Timer();
            timer.Add("Test Client", "Test Project", "");
            TimeEntry entry = new TimeEntry("Test Client", "Test Project", "Updated Entry");

            timer.Add("Test Client", "Test Project","A Project for the test client");
            timer.Update(1, entry);

            TimeEntry updatedEntry = timer.Entries[1];
            
            Assert.Equal(1, updatedEntry.Id);
            Assert.Equal("Updated Entry", updatedEntry.Note);
        }

        [Fact]
        public void PrintEntries_LogsAStringOfEntriesToTheConsole()
        {
            Timer timer = new Timer();
            timer.Add("Test Client", "Test Project", "");
            timer.Add("Test Client 2", "Test Project 2", "A project for the other client");

            string expectedStr =
                "Test Client, Test Project, \nTest Client 2, Test Project 2, A project for the other client\n";
            
            var output = new StringWriter();
            Console.SetOut(output);

            timer.PrintEntries();
            
            var outputString = output.ToString(); 
            
            Assert.Equal(expectedStr, outputString);
        }
    }
}