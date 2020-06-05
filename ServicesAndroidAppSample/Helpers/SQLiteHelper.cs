using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ServicesAndroidAppSample.Models;
using SQLite;

namespace ServicesAndroidAppSample.Helpers
{
    public class SQLiteHelper
    {
        private SQLiteConnection connection;
        public SQLiteHelper()
        {
            this.CreateConnection();
            if (this.connection.TableMappings.All(e => e.TableName != nameof(UserModel)))
                this.connection.CreateTable<UserModel>();
        }
        private void CreateConnection()
        {
            string path = Path.Combine(
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal),
                "servicesandroidapp.sqlite");
            this.connection = new SQLiteConnection(path);
        }

        public void Insert<T>(T model)
        {
            this.connection.Insert(model);
            this.connection.Commit();
        }

        public IEnumerable<T> Retrieve<T>() where T : new() =>
            this.connection.Table<T>();

        public void DeleteAll() => 
            this.connection.DeleteAll<UserModel>();

        public void CloseConnection() => this.connection.Close();

    }
}