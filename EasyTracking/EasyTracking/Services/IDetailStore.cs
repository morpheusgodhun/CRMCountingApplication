using System;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public interface IDetailStore<T> {

        Task<bool> UpdateItemAsync(long id, DateTime date, int userId);
        Task<T> GetItemAsync(long id);
    }
}