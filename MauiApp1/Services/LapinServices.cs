using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MauiApp1.ViewModels;

namespace MauiApp1.Services
{
    public class LapinServices : ILapinServices
    {
        private SQLiteAsyncConnection _dbConnection;

        private readonly HomeViewModel _homeViewModel;

        public LapinServices(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }
        private async Task SetUpDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);

            // Créer la table User
            await _dbConnection.CreateTableAsync<Lapin>();
        }
        public event EventHandler<DataUpdatedEventArgs> DataUpdated;
        public async Task<bool> AddLapin(Lapin lapin)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.InsertAsync(lapin);
            if (result == 1)
            {
                DataUpdated?.Invoke(this, new DataUpdatedEventArgs());

                _homeViewModel.AjouterLapin(lapin);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteLapin(Lapin lapin)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.DeleteAsync(lapin);
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
        public async Task<List<Lapin>> GetLapinList()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var lapinlist = await _dbConnection.Table<Lapin>().ToListAsync();

            return lapinlist;
        }
        public async Task<bool> UpdateLapin(Lapin lapin)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.UpdateAsync(lapin);
            if (result == 1)
            {
                //DataUpdated?.Invoke(this, new DataUpdatedEventArgs());

                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<Lapin> GetLapin(string lapinId)
        {
            throw new NotImplementedException();
        }

        public async Task<Lapin> GetLapinById(int id)
        {
            await SetUpDb();
            return await _dbConnection.FindAsync<Lapin>(id);
        }
    }
}
