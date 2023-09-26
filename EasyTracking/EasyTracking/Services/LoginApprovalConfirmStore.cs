using EasyTracking.Datas.VehicleLoginDatas;
using EasyTracking.Models;
using System;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class LoginApprovalConfirmStore : IDetailStore<LoginApprovalConfirm> {

        #region Constructors
        public LoginApprovalConfirmStore() { }
        #endregion

        #region Variables
        private IVehicleLoginService _vehicleLoginService;
        #endregion

        #region Methods
        public async Task<bool> UpdateItemAsync(long id, DateTime date, int userId) {
            _vehicleLoginService = new VehicleLoginService(GlobalModule.User.Token);
            var result = await _vehicleLoginService.Confirm(new ConfirmLoginRequest {
                Id = id,
                LoginDate = date,
                UserId = userId
            });
            _vehicleLoginService.Dispose();

            return result;
        }

        public async Task<LoginApprovalConfirm> GetItemAsync(long id) {
            var item = new LoginApprovalConfirm();
            _vehicleLoginService = new VehicleLoginService(GlobalModule.User.Token);
            var response = await _vehicleLoginService.GetVehicleLoginAsync(id);
            _vehicleLoginService.Dispose();
            _vehicleLoginService = null;
            if (response != null) {
                item.Text = string.Concat(response.PlateNumber, string.IsNullOrEmpty(response.TrailerNumber) ? "" : " / ", response.TrailerNumber);
                item.Description = response.DriverName;
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
    }
    #endregion

}