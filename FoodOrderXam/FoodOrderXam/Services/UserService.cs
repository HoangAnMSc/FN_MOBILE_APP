using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using FoodOrderXam.Models;

// ReSharper disable All

namespace DemoApp.Services
{
    public class UserService
    {
        private FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://foodorderxam.firebaseio.com/");
        }

        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
              .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users")
               .PostAsync(new User() { Username = uname, Password = passwd });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
               .OnceAsync<User>()).Where(u => u.Object.Username == uname)
               .Where(u => u.Object.Password == passwd).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}