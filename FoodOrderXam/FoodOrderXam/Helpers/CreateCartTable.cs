using System;
using FoodOrderXam.Models;
using Xamarin.Forms;

//ReSharper disable all

namespace FoodOrderXam.Helpers
{
    public class CreateCartTable
    {
        public bool CreateTable()
        {
            try
            {
                var connection = DependencyService.Get<ISQLite>().GetConnection();
                connection.CreateTable<CartItem>();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}