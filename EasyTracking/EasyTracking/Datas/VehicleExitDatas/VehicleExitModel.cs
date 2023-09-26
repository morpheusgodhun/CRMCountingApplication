using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class VehicleExitModel {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("processDate")]
        public DateTime ProcessDate { get; set; }

        [JsonProperty("processTypeId")]
        public int ProcessTypeId { get; set; }

        [JsonProperty("plateNumber")]
        public string PlateNumber { get; set; }

        [JsonProperty("trailerNumber")]
        public string TrailerNumber { get; set; }

        [JsonProperty("driverName")]
        public string DriverName { get; set; }

        [JsonProperty("sealNumber")]
        public string SealNumber { get; set; }

        [JsonProperty("isLoading")]
        public bool IsLoading { get; set; }

        [JsonProperty("loadingDate")]
        public DateTime? LoadingDate { get; set; }

        [JsonProperty("isConfirm")]
        public bool IsConfirm { get; set; }

        [JsonProperty("isExit")]
        public bool IsExit { get; set; }

        [JsonProperty("declarationStatusId")]
        public int? DeclarationStatusId { get; set; }

        [JsonProperty("t1StatusId")]
        public int? T1StatusId { get; set; }

        [JsonProperty("isReadyExit")]
        public bool IsReadyExit { get; set; }

        [JsonProperty("exitItems")]
        public List<ItemExitModel> ExitItems { get; set; }

        [JsonProperty("deleteItems")]
        public List<ItemExitModel> DeleteItems { get; set; }
    }
}