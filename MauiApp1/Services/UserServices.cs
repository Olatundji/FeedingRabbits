using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class UserServices : IUserServices
    {
        private SQLiteAsyncConnection _dbConnection;
        public UserServices()
        {
            SetUpDb();
        }
        private async void SetUpDb()
        {
            //Créer la base de donnée
            if (_dbConnection == null)
            {
                string dbPath= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                //créer la table User
               await _dbConnection.CreateTableAsync<User>();
            }
        }
        public async Task<bool> AddUser(User user)
        {
            var result = await _dbConnection.InsertAsync(user);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public async Task<bool> DeleteUser(User user)
        {

            var result = await _dbConnection.DeleteAsync(user);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Pour appeler la liste des utilisateurs
        public async Task<List<User>> GetUserList()
       {
            var userList = await _dbConnection.Table<User>().ToListAsync();

            return userList;
        }

        public async Task<bool> UpdateUser(User user)
        {

            var result = await _dbConnection.UpdateAsync(user);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser()
        {
            // Implémentation pour récupérer l'utilisateur existant de la base de données
            // Utilisez votre logique spécifique pour récupérer l'utilisateur existant, par exemple en utilisant une requête LINQ

            // Exemple de code pour récupérer l'utilisateur existant à partir d'une source de données fictive
            var existingUser = await _dbConnection.Table<User>().FirstOrDefaultAsync();
            return existingUser;
        }


        //public async Task<bool> DeleteUser(int id)
        //{

        //    var result = await _dbConnection.Remove(user.Id);
        //    if (result == 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
