using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public  interface IAlimentationServices
    {
        double CalculerQuantiteAliment(string categorie, double poids, DateTime naissance, string nom);
        double CalculerQuantiteEau(string categorie, string nom);
        Task<Lapin> GetLapinById(int id);
        Task<Aliment> GetAlimentById(int id);
        Task<IEnumerable<Lapin>> GetAllLapins();
        Task<IEnumerable<Aliment>> GetAllAliments();
        Task UpdateAliment(Aliment aliment);
        
    }
}
