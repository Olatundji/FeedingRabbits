using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class HomeServices : IHomeServices
    {
        private List<Lapin> _lapins;

        public HomeServices()
        {
            _lapins = HomeServices.LoadData();
        }
        public List<Lapin> GetLapins()
        {
            return _lapins;
        }
        public double CalculerTauxMortaliter(List<Lapin> lapins)
        {
            if (lapins == null || lapins.Count == 0)
                return 0;

            int deceasedLapinsCount = lapins.Count(lapin => lapin.Deces);
            double mortalityRate = (double)deceasedLapinsCount / lapins.Count * 100;
            return Math.Round(mortalityRate, 2);
        }
        public int CountLapinsMalade(List<Lapin> lapins)
        {
            if (lapins == null || lapins.Count == 0)
                return 0;

            // Ajoutez ici la logique pour compter le nombre de lapins malades dans la liste fournie
            // Exemple :
            int maladeLapinsCount = lapins.Count(lapin => lapin.Malade);
            return maladeLapinsCount;
        }
        private static List<Lapin> LoadData()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");

            using (var dbConnection = new SQLiteConnection(dbPath))
            {
                if (dbConnection.TableMappings.All(m => m.MappedType.Name != typeof(Lapin).Name))
                {
                    dbConnection.CreateTable<Lapin>();
                }

                return dbConnection.Table<Lapin>().ToList();
            }
        }
    }
}
