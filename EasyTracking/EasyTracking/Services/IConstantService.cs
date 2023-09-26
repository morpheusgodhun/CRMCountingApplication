using System;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public interface IConstantService : IDisposable {
        Task<DateTime> GetDateTime();
    }
}