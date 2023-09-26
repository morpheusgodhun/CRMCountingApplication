using Newtonsoft.Json;
using System;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class BaseVehicleExit {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("processDate")]
        public DateTime ProcessDate { get; set; }

        [JsonProperty("processTypeName")]
        public string ProcessTypeName { get; set; }

        [JsonProperty("plateNumber")]
        public string PlateNumber { get; set; }

        [JsonProperty("trailerNumber")]
        public string TrailerNumber { get; set; }

        [JsonProperty("driverName")]
        public string DriverName { get; set; }

        [JsonProperty("sealNumber")]
        public string SealNumber { get; set; }

        [JsonProperty("createdTime")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("createdUserName")]
        public string CreatedUserName { get; set; }

        [JsonProperty("updatedTime")]
        public DateTime? UpdatedTime { get; set; }

        [JsonProperty("updatedUserName")]
        public string UpdatedUserName { get; set; }

        [JsonProperty("isLoading")]
        public bool IsLoading { get; set; }

        [JsonProperty("loadingDate")]
        public DateTime? LoadingDate { get; set; }
    }
}