using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookStore
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath
      (System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                connection.CreateTable<Book>();
                connection.CreateTable<Cart>();
                connection.CreateTable<User>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddBook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(book);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Book>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteOnebook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                connection.Delete(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOnebook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                connection.Update(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddCart(Cart cart)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(cart);
                return true;
            }
            catch
            {

                return false;
            }
        }
        
        public List<Cart> GetCart()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<Cart>().ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Book> GetOneBook(int bId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                return connection.Query<Book>("select * from Book where bId=" + bId.ToString());
            }
            catch
            {
                return null;
            }
        }

        public bool AddUser(User user)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(user);
                return true;
            }
            catch
            {

                return false;
            }
        }
        public List<User> GetUser()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "bookstore.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<User>().ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}
