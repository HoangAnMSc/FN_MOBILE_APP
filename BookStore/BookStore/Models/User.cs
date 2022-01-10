using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookStore
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public string Phone { get; set; }
    }
}
