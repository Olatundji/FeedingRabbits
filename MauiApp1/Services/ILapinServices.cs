using MauiApp1.Models;
using MauiApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface ILapinServices
    {
        Task<List<Lapin>> GetLapinList();

        Task<bool> AddLapin(Lapin lapin);

        Task<bool> UpdateLapin(Lapin lapin);

        Task<bool> DeleteLapin(Lapin lapin);
        Task<Lapin> GetLapinById(int id);

        //public event EventHandler<DataUpdatedEventArgs> DataUpdated;

        //Task<Lapin> GetLapin(string lapinId);
    }
}
