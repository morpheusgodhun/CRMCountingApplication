using EasyTracking.Datas.VehicleLoginDatas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public interface IVehicleLoginService : IDisposable {

        Task<List<VehicleLoginModel>> GetVehicleLoginsAsync();
        Task<GetVehicleLoginModel> GetVehicleLoginAsync(long id);
        Task<bool> Confirm(ConfirmLoginRequest request);
    }
}