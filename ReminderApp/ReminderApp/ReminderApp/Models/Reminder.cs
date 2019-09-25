using System;
using SQLite;
namespace ReminderApp.Models
{
    public class Reminder
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }

        public Reminder()
        {

        }

        public Reminder(string title, string date, string description, string time)
        {
            Title = title;
            Date = date;
            Description = description;
            Time = time;
        }
    }
}
