using System;
using System.IO;
using FoodOrderXam.Models;
using SQLite;
using Xamarin.Forms;

//ReSharper disable all

[assembly: Dependency(typeof(FoodOrderXam.Droid.SQLite_Android))]

namespace FoodOrderXam.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "FoodDb.db3";

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}