using System;
using System.Data;
using System.IO;
using SQLite;

namespace DBDemo.ORM
{
    public class DBRepository
    {
        //Code to create database
        public string CreateDB()
        {
            var output = "";
            output += "Creating Databese if it doesn't exist.";
            string dbPath = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            output += "\nDatabase Created...";
            return output;
        }

        //Code to create the table
        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<ToDoTasks>();
                string result = "Table Created successfully...";
                return result;

            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //Code to insert a record
        public string InsertRecord(string task)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);

                ToDoTasks item = new ToDoTasks();
                item.Task = task;
                db.Insert(item);
                return "Record Added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //Code to retrieve all the records
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving the data using ORM...";

            try
            {
                var table = db.Table<ToDoTasks>();
                foreach (var item in table)
                {
                    output += "\n" + item.Id + " --- " + item.Task;
                }
                return output;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
            
        }

        //Code to retrieve specific record
        public string GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            try
            {
                var item = db.Get<ToDoTasks>(id);
                return item.Task;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
            
        }

        //Method to update the record using ORM
        public string updateRecord(int id, string task)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);            

            try
            {
                var item = db.Get<ToDoTasks>(id);
                item.Task = task;
                db.Update(item);
                return "Record Updated...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //Method to remove the record using ORM
        public string DeleteTask(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            
            try
            {
                var item = db.Get<ToDoTasks>(id);
                db.Delete(item);
                return "Record Deleted...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

    }
}