using EasyTracking.Datas.VehicleExitDatas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class VehicleExitService : IVehicleExitService {

        #region Constructors
        public VehicleExitService(string token) {
            service = new HttpApiService(token);
        }
        #endregion

        #region Variables
        private IHttpApiService service;
        private bool _disposed;
        #endregion

        #region Methods
        public async Task<List<VehcileExitConfirmModel>> GetVehicleExitConfirmsAsync() {
            List<VehcileExitConfirmModel> vehicleExits = null;
            var response = await service.GetAsync<VehicleExitConfirmResponse>("VehicleExits/VehicleExitConfirms");
            if (response != null)
                vehicleExits = response.VehicleExits;

            return vehicleExits;
        }

        public async Task<VehicleExitModel> GetVehicleExitConfirmAsync(long id) {
            VehicleExitModel vehicleExit = null;
            service.AddHeader("x-requestid", id.ToString());
            var response = await service.GetAsync<GetVehicleExitConfirmResponse>("VehicleExits/GetVehicleExitConfirm");

            if (response != null) {
                vehicleExit = response.VehicleExit;
                if (!response.Success)
                    if (!string.IsNullOrEmpty(response.Message))
                        throw new Exception(response.Message);
            }

            return vehicleExit;
        }

        public async Task<bool> VehicleExitApprovalAsync(VehicleExitApprovalRequest request) {
            var response = await service.PutAsync<VehicleExitApprovalRequest, VehicleExitApprovalResponse>("VehicleExits/ConfirmVehicleExit", request);
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

        ~VehicleExitService() {
            Dispose(disposing: false);
        }
        #endregion

    }
}