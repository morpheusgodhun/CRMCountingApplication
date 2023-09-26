using EasyTracking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class LoginApprovalStore : IDataStore<LoginApproval> {

        #region Constructors
        public LoginApprovalStore() { }
        #endregion

        #region Variables
        private IVehicleLoginService _vehicleLoginService;
        private List<LoginApproval> items;
        #endregion

        #region Methods
        public async Task<IEnumerable<LoginApproval>> GetItemsAsync(bool forceRefresh = false) {
            _vehicleLoginService = new VehicleLoginService(GlobalModule.User.Token);
            var vehicleLogins = await _vehicleLoginService.GetVehicleLoginsAsync();
            items = new List<LoginApproval>();
            if (vehicleLogins != null) {
                foreach (var item in vehicleLogins) {
                    items.Add(new LoginApproval {
                        Id = item.Id,
                        Text = string.IsNullOrEmpty(item.TrailerNumber) ? item.PlateNumber : item.PlateNumber + " - " + item.TrailerNumber,
                        Description = string.Concat(item.DriverName, "\n", item.ProcessTypeName, "\n", item.SealNumber)
                    });
                }
                vehicleLogins.Clear();
            }
            _vehicleLoginService.Dispose();
            _vehicleLoginService = null;
            return await Task.FromResult(items);
        }
        #endregion

    }
}