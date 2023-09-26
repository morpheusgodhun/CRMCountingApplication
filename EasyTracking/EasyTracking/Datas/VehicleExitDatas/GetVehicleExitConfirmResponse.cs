using Newtonsoft.Json;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class GetVehicleExitConfirmResponse : BaseResponse {

        [JsonProperty("vehicleExit")]
        public VehicleExitModel VehicleExit { get; set; }
    }
}
