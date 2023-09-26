using Newtonsoft.Json;
using System;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class VehicleExitApprovalRequest {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("logoutDate")]
        public DateTime LogoutDate { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}