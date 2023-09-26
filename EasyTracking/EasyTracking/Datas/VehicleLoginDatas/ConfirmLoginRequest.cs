using Newtonsoft.Json;
using System;

namespace EasyTracking.Datas.VehicleLoginDatas {
    public class ConfirmLoginRequest {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("loginDate")]
        public DateTime LoginDate { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}