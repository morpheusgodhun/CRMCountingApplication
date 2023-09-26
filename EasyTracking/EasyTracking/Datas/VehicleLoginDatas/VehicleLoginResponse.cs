using Newtonsoft.Json;
using System.Collections.Generic;

namespace EasyTracking.Datas.VehicleLoginDatas {
    public class VehicleLoginResponse : BaseResponse {

        [JsonProperty("vehicleLogins")]
        public List<VehicleLoginModel> VehicleLogins { get; set; }
    }
}