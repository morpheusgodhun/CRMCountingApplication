using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class VehicleExitConfirmResponse : BaseResponse {
        [JsonProperty("vehicleExits")]
        public List<VehcileExitConfirmModel> VehicleExits { get; set; }
    }

    public class VehcileExitConfirmModel : BaseVehicleExit {

        [JsonProperty("readyExitDate")]
        public DateTime? ReadyExitDate { get; set; }

        [JsonProperty("readyUserFullName")]
        public string ReadyUserFullName { get; set; }
    }
}