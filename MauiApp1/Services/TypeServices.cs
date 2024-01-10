using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class TypeServices : ITypeServices
    {
        private SQLiteAsyncConnection _dbConnection;

        public TypeServices()
        {
            // Ne rien initialiser ici
        }
        private async Task SetUpDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);

            //    Créer la table User
            await _dbConnection.CreateTableAsync<LapinType>();
        }

        public async Task<bool> AddType(LapinType lapintype)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.InsertAsync(lapintype);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteType(LapinType lapintype)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.DeleteAsync(lapintype);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<LapinType>> GetTypeList()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var typeList = await _dbConnection.Table<LapinType>().ToListAsync();

            return typeList;
        }

        public async Task<bool> UpdateType(LapinType lapintype)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.UpdateAsync(lapintype);
            if (result == 1)
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
