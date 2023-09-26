using EasyTracking.Datas.VehicleExitDatas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public interface IVehicleExitService : IDisposable {

        Task<List<VehcileExitConfirmModel>> GetVehicleExitConfirmsAsync();
        Task<VehicleExitModel> GetVehicleExitConfirmAsync(long id);
        Task<bool> VehicleExitApprovalAsync(VehicleExitApprovalRequest request);
    }
}