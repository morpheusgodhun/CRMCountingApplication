using EasyTracking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTracking.Services {
    public class ExitApprovalStore : IDataStore<ExitApproval> {

        #region Constructors
        public ExitApprovalStore() { }
        #endregion

        #region Varibales
        private List<ExitApproval> items;
        private IVehicleExitService _vehicleExitService;
        #endregion

        #region Methods
        public async Task<IEnumerable<ExitApproval>> GetItemsAsync(bool forceRefresh = false) {
            _vehicleExitService = new VehicleExitService(GlobalModule.User.Token);
            var vehicleLogins = await _vehicleExitService.GetVehicleExitConfirmsAsync();
            items = new List<ExitApproval>();
            if (vehicleLogins != null) {
                foreach (var item in vehicleLogins) {
                    items.Add(new ExitApproval {
                        Id = item.Id,
                        Text = string.IsNullOrEmpty(item.TrailerNumber) ? item.PlateNumber : item.PlateNumber + " - " + item.TrailerNumber,
                        Description = string.Concat(item.DriverName, "\n", item.ProcessTypeName, "\n", item.SealNumber)
                    });
                }
                vehicleLogins.Clear();
            }
            _vehicleExitService.Dispose();
            _vehicleExitService = null;
            return await Task.FromResult(items);
        }
        #endregion

    }
}