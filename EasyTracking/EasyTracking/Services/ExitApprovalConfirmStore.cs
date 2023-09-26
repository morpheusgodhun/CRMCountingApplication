using EasyTracking.Datas.VehicleExitDatas;
using EasyTracking.Models;
using System;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class ExitApprovalConfirmStore : IDetailStore<ExitApprovalConfirm> {

        #region Constructors
        public ExitApprovalConfirmStore() { }
        #endregion

        #region Variables
        private IVehicleExitService _vehicleExitService;
        #endregion

        #region Methods
        public async Task<ExitApprovalConfirm> GetItemAsync(long id) {
            var item = new ExitApprovalConfirm();
            _vehicleExitService = new VehicleExitService(GlobalModule.User.Token);
            var response = await _vehicleExitService.GetVehicleExitConfirmAsync(id);
            _vehicleExitService.Dispose();
            _vehicleExitService = null;
            if (response != null) {
                item.Text = string.Concat(response.PlateNumber, string.IsNullOrEmpty(response.TrailerNumber) ? "" : " / ", response.TrailerNumber);
                item.Description = response.DriverName;
                item.SealNumber = response.SealNumber;
                switch (response.ProcessTypeId) {
                    case 101:
                        item.ProcessTypeName = "Personel";
                        break;
                    case 102:
                        item.ProcessTypeName = "Ziyaretçi";
                        break;
                    case 103:
                        item.ProcessTypeName = "Boş Araç";
                        break;
                    case 104:
                        item.ProcessTypeName = "İrsaliyeli/ Yüklü";
                        break;
                    case 105:
                        item.ProcessTypeName = "İhracat Yüklü";
                        break;
                    case 106:
                        item.ProcessTypeName = "Sevkli Araç";
                        break;
                    default:
                        break;
                }
            }
            return item;
        }

        public async Task<bool> UpdateItemAsync(long id, DateTime date, int userId) {
            _vehicleExitService = new VehicleExitService(GlobalModule.User.Token);
            var result = await _vehicleExitService.VehicleExitApprovalAsync(new VehicleExitApprovalRequest {
                Id = id,
                LogoutDate = date,
                UserId = userId
            });
            _vehicleExitService.Dispose();

            return result;
        }
        #endregion

    }
}