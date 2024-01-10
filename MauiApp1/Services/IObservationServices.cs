using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IObservationServices
    {
        //Task<List<Observation>> GetObservationByLapinId(int lapinId);
        Task<List<Observation>> GetObservationList();

        Task<bool> AddObservation(Observation observation);

        Task<bool> UpdateObservation(Observation observation);

        Task<bool> DeleteObservation(Observation observation);
    }
}
