using System;
using EasyTracking.Models;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public interface IUserService : IDisposable {
        Task<User> GetUser(string userName, string password);
        Task<MainMenu> GetMainMenu(int userId);
    }
}