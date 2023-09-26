using Newtonsoft.Json;
using System;

namespace EasyTracking.Datas.VehicleLoginDatas {
    public class VehicleLoginModel {

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

        [JsonProperty("reasonToVisit")]
        public string ReasonToVisit { get; set; }

        [JsonProperty("personnelFullName")]
        public string PersonnelFullName { get; set; }

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
    }
}