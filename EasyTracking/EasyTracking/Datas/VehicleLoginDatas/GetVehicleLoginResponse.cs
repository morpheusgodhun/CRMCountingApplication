using Newtonsoft.Json;

namespace EasyTracking.Datas.VehicleLoginDatas {
    public class GetVehicleLoginResponse : BaseResponse {

        [JsonProperty("getVehicleLoginModel")]
        public GetVehicleLoginModel GetVehicleLogin { get; set; }
    }
}