using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class HttpApiService : IHttpApiService {

        #region Constructors
        public HttpApiService(string token = "") {
            client = CreateHttpClient(token);
        }
        #endregion

        #region Variables
        private const string baseUrl = "https://192.168.0.7:7204/api/v1/";
        private bool _disposed;
        private HttpClient client;
        private HttpResponseMessage response;
        private StringContent content;
        private string serialized;
        #endregion

        #region Private Methods
        private HttpClient CreateHttpClient(string token = "") {
            var httpClient = new HttpClient(GetInsecureHandler());
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(baseUrl);
            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpClient;
        }

        private HttpClientHandler GetInsecureHandler() {
            return new HttpClientHandler() {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => {
                    return true;
                }
            };
        }
        #endregion

        #region Public Methods
        public void AddHeader(string key, string value) {
            client.DefaultRequestHeaders.Add(key, value);
        }

        public async Task<TResult> GetAsync<TResult>(string uri) {
            try {
                response = await client.GetAsync(uri);
                serialized = await response.Content.ReadAsStringAsync();

                var result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<TResult>(serialized));
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<TResult> PostAsync<TData, TResult>(string uri, TData data) {
            TResult result = default;
            try {
                content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                serialized = await response.Content.ReadAsStringAsync();
                if (serialized != null) {
                    result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<TResult>(serialized));
                    serialized = null;
                }
                content = null;
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<TResult> PutAsync<TData, TResult>(string uri, TData data) {
            TResult result = default;
            try {
                content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
                serialized = await response.Content.ReadAsStringAsync();
                if (serialized != null) {
                    result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<TResult>(serialized));
                    serialized = null;
                }
                content = null;
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        #region IDisposable Support
        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    client?.Dispose();
                    client = null;
                    content = null;
                    response = null;
                }
                _disposed = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~HttpApiService() {
            Dispose(disposing: false);
        }
        #endregion

    }
}
