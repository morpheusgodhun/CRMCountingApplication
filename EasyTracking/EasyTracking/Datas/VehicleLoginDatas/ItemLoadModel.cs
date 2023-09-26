using EasyTracking.Enums;
using Newtonsoft.Json;

namespace EasyTracking.Datas.VehicleLoginDatas {
    public class ItemLoadModel {

        [JsonProperty("caseCount")]
        public int CaseCount { get; set; }
        [JsonProperty("caseCountType")]
        public string CaseCountType { get; set; }
        [JsonProperty("consigneeId")]
        public int? ConsigneeId { get; set; }
        [JsonProperty("declarationNumber")]
        public string DeclarationNumber { get; set; }
        [JsonProperty("entityStateType")]
        public EntityStateType EntityStateType { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        [JsonProperty("orderNo")]
        public string OrderNo { get; set; }
        [JsonProperty("rowId")]
        public int RowId { get; set; }
        [JsonProperty("shipperId")]
        public int? ShipperId { get; set; }
        [JsonProperty("t1Number")]
        public string T1Number { get; set; }
        [JsonProperty("weight")]
        public double Weight { get; set; }
        [JsonProperty("weightType")]
        public string WeightType { get; set; }
    }
}