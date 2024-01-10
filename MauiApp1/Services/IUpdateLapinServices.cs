using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IUpdateLapinServices
    {
        Task<List<Lapin>> GetLapinList();
        Task<bool> AddLapin(Lapin lapin);

        Task<bool> UpdateLapin(Lapin lapin);

        Task<bool> DeleteLapin(Lapin lapin);
    }
}
