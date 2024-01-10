using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ObservationServices : IObservationServices
    {
        private SQLiteAsyncConnection _dbConnection;

        public ObservationServices()
        {

        }
        private async Task SetUpDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);

            // Créer la table User
            await _dbConnection.CreateTableAsync<Observation>();
        }
        public async Task<bool> AddObservation(Observation observation)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.InsertAsync(observation);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteObservation(Observation observation)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.DeleteAsync(observation);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public async Task<List<Observation>> GetObservationByLapinId(int lapinId)
        //{
        //    if (_dbConnection == null)
        //    {
        //        await SetUpDb();
        //    }
        //    var query = _dbConnection.Table<Observation>()
        //        .Where(observation => observation.LapinId == lapinId);

        //    return await query.ToListAsync();
        //    // return  await _dbConnection.Table<Observation>().Where(o => o.LapinId == lapinId).ToListAsync();
        //}

        public async Task<bool> UpdateObservation(Observation observation)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var result = await _dbConnection.UpdateAsync(observation);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<Observation>> GetObservationList()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var observationlist = await _dbConnection.Table<Observation>().ToListAsync();

            return observationlist;
        }
    }
     
}
