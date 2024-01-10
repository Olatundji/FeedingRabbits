using MauiApp1.Models;
using MauiApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class UpdateLapinServices : IUpdateLapinServices
    {
        private readonly LapinServices lapinServices;

        public UpdateLapinServices(ILapinServices lapinServices)
        {
            this.lapinServices = (LapinServices)lapinServices;
        }

        public async Task<List<Lapin>> GetLapinList()
        {
            return await lapinServices.GetLapinList();
        }

        public async Task<bool> AddLapin(Lapin lapin)
        {
            return await lapinServices.AddLapin(lapin);
        }

        public async Task<bool> UpdateLapin(Lapin lapin)
        {
            return await lapinServices.UpdateLapin(lapin);
        }

        public async Task<bool> DeleteLapin(Lapin lapin)
        {
            return await lapinServices.DeleteLapin(lapin);
        }
    }
}
