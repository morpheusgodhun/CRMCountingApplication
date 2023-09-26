using EasyTracking.Datas;
using System;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class ConstantService : IConstantService {

        #region Constructors
        public ConstantService(string token) {
            service = new HttpApiService(token);
        }
        #endregion

        #region Variables
        private IHttpApiService service;
        private bool _disposed;
        #endregion

        #region Methods
        public async Task<DateTime> GetDateTime() {
            DateTime date = DateTime.Now;
            var response = await service.GetAsync<DateTimeResponse>("Constant/GetServerDateTime");
            if (response != null) {
                if (response.GetDateTimeModel != null) {
                    date = response.GetDateTimeModel.ServerDateTime;
                }
            }
            return date;
        }
        #endregion

        #region IDisposable Support
        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    service?.Dispose();
                    service = null;
                }
                _disposed = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~ConstantService() {
            Dispose(disposing: false);
        }
        #endregion

    }
}
