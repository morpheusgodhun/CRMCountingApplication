using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EasyTracking.Datas.VehicleLoginDatas {
    public class GetVehicleLoginModel {

        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("isExit")]
        public bool IsExit { get; set; }
        [JsonProperty("isLoading")]
        public bool IsLoading { get; set; }
        [JsonProperty("isLogin")]
        public bool IsLogin { get; set; }
        [JsonProperty("isUnLoading")]
        public bool IsUnLoading { get; set; }
        [JsonProperty("itemLoads")]
        public List<ItemLoadModel> ItemLoads { get; set; }
        [JsonProperty("personnelId")]
        public int? PersonnelId { get; set; }
        [JsonProperty("plateNumber")]
        public string PlateNumber { get; set; }
        [JsonProperty("processDate")]
        public DateTime ProcessDate { get; set; }
        [JsonProperty("processTypeId")]
        public int ProcessTypeId { get; set; }
        [JsonProperty("reasonToVisit")]
        public string ReasonToVisit { get; set; }
        [JsonProperty("sealNumber")]
        public string SealNumber { get; set; }
        [JsonProperty("trailerNumber")]
        public string TrailerNumber { get; set; }
    }
}