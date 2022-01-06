using SQLite;

//ReSharper disable all

namespace FoodOrderXam.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}