using System;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public interface IHttpApiService 
        : IDisposable {
        
        Task<TResult> GetAsync<TResult>(string uri);
        Task<TResult> PostAsync<TData, TResult>(string uri, TData data);
        Task<TResult> PutAsync<TData, TResult>(string uri, TData data);
        void AddHeader(string key, string value);
    }
}