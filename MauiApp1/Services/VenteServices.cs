using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class VenteServices : IVenteServices
    {
        private SQLiteAsyncConnection _dbConnection;

        public VenteServices()
        {

        }
        private async Task SetUpDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);

            // Créer la table User
            await _dbConnection.CreateTableAsync<Vente>();
        }
        public async Task<bool> AddVente(Vente vente)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.InsertAsync(vente);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteVente(Vente vente)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.DeleteAsync(vente);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Vente>> GetVenteList()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var ventelist = await _dbConnection.Table<Vente>().ToListAsync();

            return ventelist;
        }

        public async Task<bool> UpdateVente(Vente vente)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.UpdateAsync(vente);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        
            public async Task<List<Lapin>> GetLapinList()
            {
                if (_dbConnection == null)
                {
                    await SetUpDb();
                }

                var lapinlist = await _dbConnection.Table<Lapin>().ToListAsync();

                return lapinlist;
            }
     
    }
}
