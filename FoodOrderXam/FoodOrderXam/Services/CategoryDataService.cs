using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using FoodOrderXam.Models;

// ReSharper disable All

namespace FoodOrderXam.Services
{
    public class CategoryDataService
    {
        private FirebaseClient _client;

        public CategoryDataService()
        {
            _client = new FirebaseClient("https://foodorderxam.firebaseio.com/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await _client.Child("Categories")
                .OnceAsync<Category>())
                .Select(cat => new Category
                {
                    CategoryID = cat.Object.CategoryID,
                    CategoryName = cat.Object.CategoryName,
                    CategoryPoster = cat.Object.CategoryPoster,
                    ImageUrl = cat.Object.ImageUrl
                }).ToList();
            return categories;
        }
    }
}