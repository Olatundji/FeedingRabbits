using MauiApp1.Models;
using MauiApp1.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class AlimentServices : IAlimentServices
    {
        private SQLiteAsyncConnection _dbConnection;
        
        public AlimentServices()
        {
            // Ne rien initialiser ici
        }
        private async Task SetUpDb()
        {
              string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
             _dbConnection = new SQLiteAsyncConnection(dbPath);

            //    Créer la table User
            await _dbConnection.CreateTableAsync<Aliment>();
        }
        public event EventHandler<DataUpdatedEventArgs> DataUpdated;
        public async Task<bool> AddAliment(Aliment aliment)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.InsertAsync(aliment);
            if (result == 1)
            {
                DataUpdated?.Invoke(this, new DataUpdatedEventArgs());
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteAliment(Aliment aliment)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.DeleteAsync(aliment);
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
        public async Task<List<Aliment>> GetAlimentList()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var alimentlist = await _dbConnection.Table<Aliment>().ToListAsync();

            return alimentlist;
        }

        public async Task<bool> UpdateAliment(Aliment aliment)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.UpdateAsync(aliment);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Aliment> GetAlimentById(int id)
        {
            await SetUpDb();
            return await _dbConnection.FindAsync<Aliment>(id);
        }
    }
}




