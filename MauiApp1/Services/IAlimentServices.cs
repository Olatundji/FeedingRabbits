using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IAlimentServices
    {
        Task<List<Aliment>> GetAlimentList();

        Task<bool> AddAliment(Aliment aliment);
        Task<bool> UpdateAliment(Aliment aliment);

        Task<bool> DeleteAliment(Aliment aliment);
        Task<Aliment> GetAlimentById(int id);
    }
}
