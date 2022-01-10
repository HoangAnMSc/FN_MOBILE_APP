using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookStore
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int cId {  get; set; }
        public int bId {  get; set; }
        public int totalAmount {  get; set; }
    }
    
}
