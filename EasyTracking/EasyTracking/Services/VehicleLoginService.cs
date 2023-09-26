using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using EasyTracking.Datas.VehicleLoginDatas;

namespace EasyTracking.Services {
    public class VehicleLoginService : IVehicleLoginService {

        #region Constructors
        public VehicleLoginService(string token) {
            service = new HttpApiService(token);
        }
        #endregion

        #region Variables
        private IHttpApiService service;
        private bool _disposed;
        #endregion

        #region Methods
        public async Task<List<VehicleLoginModel>> GetVehicleLoginsAsync() {

            List<VehicleLoginModel> vehicleLogins = null;
            var response = await service.GetAsync<VehicleLoginResponse>("VehiclesLoad/GetVehicleLogins");
            if (response != null) {
                vehicleLogins = response.VehicleLogins;
            }
            return vehicleLogins;
        }

        public async Task<GetVehicleLoginModel> GetVehicleLoginAsync(long id) {
            service.AddHeader("x-requestid", id.ToString());
            GetVehicleLoginModel data = null;
            var response = await service.GetAsync<GetVehicleLoginResponse>("VehiclesLoad/GetVehicleLogin");
            if (response != null) {
                data = response.GetVehicleLogin;
                if (!response.Success)
                    if (!string.IsNullOrEmpty(response.Message))
                        throw new Exception(response.Message);
            }
            return data;
        }

        public async Task<bool> Confirm(ConfirmLoginRequest request) {

            var response = await service.PutAsync<ConfirmLoginRequest, ConfirmLoginResponse>("VehiclesLoad/ConfirmVehicleLogin", request);
            bool result = false;
            if (response != null) {
                result = response.Success;
                if (!string.IsNullOrEmpty(response.Message))
                    throw new Exception(response.Message);
            }
            return result;
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

        ~VehicleLoginService() {
            Dispose(disposing: false);
        }
        #endregion

    }
}
