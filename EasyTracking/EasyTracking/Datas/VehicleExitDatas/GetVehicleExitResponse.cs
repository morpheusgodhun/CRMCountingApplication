using Newtonsoft.Json;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class GetVehicleExitResponse : BaseResponse {

        [JsonProperty("vehicleExit")]
        public VehicleExitModel VehicleExit { get; set; }
    }
}
