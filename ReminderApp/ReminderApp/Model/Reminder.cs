using System;
using SQLite;
namespace ReminderApp.Model
{
    public class Reminder
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Description { get; set; }

        public Reminder()
        {

        }

        public Reminder(string title, DateTime dateTime, string description)
        {
            Title = title;
            ReminderDate = dateTime;
            Description = description;
        }
    }
}
