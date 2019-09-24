using System;
using ReminderApp.Model;
using MarcTron.Plugin;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReminderApp.Data
{
    public class Database
    {
        public SQLiteAsyncConnection Reminder_Database { get; private set; }

        public Database()
        {
            Reminder_Database = MtSql.Current.GetConnectionAsync("reminder.db");
            Reminder_Database.CreateTableAsync<Reminder>().Wait();
        }

       /* public void AddData(string title, string description, DateTime reminderDate)
        {
            Reminder_Database.InsertAsync(new Reminder { Title = title, Description = description, ReminderDate = reminderDate});
        }*/

        public async Task<List<Reminder>> GetAllRemindersAsync()
        {
            return await Reminder_Database.Table<Reminder>().ToListAsync();
        }

        public async Task AddReminderAsync(Reminder newReminder)
        {
            await Reminder_Database.InsertAsync(newReminder);
        }
    }
}
