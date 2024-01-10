using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IUserServices
    {
        Task<List<User>> GetUserList();

        Task<bool> AddUser(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(User user);

        Task<User> GetUser();
        Task DeleteUser(int id);
    }
}
