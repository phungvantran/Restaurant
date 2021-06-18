using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Restaurant.Persistence;
using Restaurant.Droid.Persistence;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(SQLiteDb))]
namespace Restaurant.Droid.Persistence
{
    class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MySqlite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}