using System;
using Xunit;
using TestingXUnit;
using Xunit.Sdk;

namespace TestingXUnit.Tests
{
    public class TimeEntryTests
    {
        [Fact]
        public void Constructor_ShouldFillInValuesWithProvidedFieldsAndDefaultOnes()
        {
            TimeEntry entry = new TimeEntry(1,"Test Client", "Test Project", "Just a note");

            Assert.Equal("Test Client", entry.Client);
            Assert.Equal(DateTime.Now, entry.Started, TimeSpan.FromSeconds(1));
            Assert.Equal(DateTime.MaxValue, entry.Ended);
        }

        [Fact]
        public void End_ShouldFillInTheEndedValueWithTheCurrentTime()
        {
            TimeEntry entry = new TimeEntry(1,"Test Client", "Test Project", "Just a note");

            entry.End();

            Assert.Equal(DateTime.Now, entry.Ended, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void GetElapsed_ShouldReturnAStringOfTheElapsedTimeForTheTask()
        {
            TimeEntry entry = new TimeEntry(1,"Test Client", "Test Project", "Just a note");

            entry.End();
            entry.Ended = entry.Started.AddMinutes(1);

            Assert.Equal("0 days, 0 hours, 1 minute(s)", entry.ElapsedTime());
        }
    }
}