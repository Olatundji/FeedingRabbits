using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface ITypeServices
    {
        Task<List<LapinType>> GetTypeList();

        Task<bool> AddType(LapinType lapintype);

        Task<bool> UpdateType(LapinType lapintype);

        Task<bool> DeleteType(LapinType lapintype);
    }
}
