using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class AuthServices
    {
        private const string AuthStateKey = "AuthState";
        private const string UserNameKey = "Identifiant";
        private const string UserPasswordKey = "Password";
        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);
            var authState = Preferences.Get(AuthStateKey, false);
            return authState;
        }
        public void Login(string identifiant, string password)
        {
                Preferences.Set(AuthStateKey, true);
                Preferences.Set(UserNameKey, identifiant);
                Preferences.Set(UserPasswordKey, password);

        }


        //public static User GetLoginData(string identifiant)
        //{
        //    using (var connection = new SQLiteConnection("Data Source=GestLapin.db3;"))
        //    {
        //        // Vérifier si l'utilisateur existe dans la base de données
        //        var user = connection.Table<User>().FirstOrDefault(u => u.Login == identifiant);
        //        return user;
        //    }
        //}

        //public async Task<User> GetLoginDataAsync(string identifiant)
        //{
        //    var users = await _connection.Table<User>().ToListAsync();
        //    return users.FirstOrDefault(u => u.Login == identifiant);
        //}
        public void Logout()
        {
            Preferences.Remove(AuthStateKey);
            Preferences.Remove(UserNameKey);
            Preferences.Remove(UserPasswordKey);
        }

        public static string GetLoggedInUserName()
        {
            return Preferences.Get(UserNameKey, UserPasswordKey, string.Empty);
        }
    }
}
