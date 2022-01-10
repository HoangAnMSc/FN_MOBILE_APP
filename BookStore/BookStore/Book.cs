using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookStore
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int bID {  get; set; }
        public string title {  get; set; }
        public int price {  get; set; }
        public string img { get; set; }
    }
}
