using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IHomeServices
    {
        List<Lapin> GetLapins(); 
        double CalculerTauxMortaliter(List<Lapin> lapins);
        int CountLapinsMalade(List<Lapin> lapins);
    }
}
