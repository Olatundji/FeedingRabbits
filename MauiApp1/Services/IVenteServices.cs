using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IVenteServices
    {
        Task<List<Vente>> GetVenteList();

        Task<bool> AddVente(Vente vente);

        Task<bool> UpdateVente(Vente vente);

        Task<bool> DeleteVente(Vente vente);
        Task<List<Lapin>> GetLapinList();
    }
}
