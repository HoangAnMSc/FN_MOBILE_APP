using System;
using System.IO;
using SQLite;
using FoodOrderXam.Models;
using Xamarin.Forms;

//ReSharper disable all
[assembly: Dependency(typeof(FoodOrderXam.iOS.SQLite_iOS))]

namespace FoodOrderXam.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "FoodDb.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}