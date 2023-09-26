using EasyTracking.Enums;
using Newtonsoft.Json;
using System;

namespace EasyTracking.Datas.VehicleExitDatas {
    public class ItemExitModel {

        //[JsonProperty("id")]
        //public long Id { get; set; }

        //[JsonProperty("rowId")]
        //public int RowId { get; set; }

        //[JsonProperty("orderNo")]
        //public string OrderNo { get; set; }

        //[JsonProperty("itemName")]
        //public string ItemName { get; set; }

        //[JsonProperty("declarationNumber")]
        //public string DeclarationNumber { get; set; }

        //[JsonProperty("t1Number")]
        //public string T1Number { get; set; }

        //[JsonProperty("shipperId")]
        //public int? ShipperId { get; set; }

        //[JsonProperty("consigneeId")]
        //public int? ConsigneeId { get; set; }

        //[JsonProperty("caseCount")]
        //public int CaseCount { get; set; }

        //[JsonProperty("caseCountType")]
        //public string CaseCountType { get; set; }

        //[JsonProperty("weight")]
        //public double Weight { get; set; }

        //[JsonProperty("weightType")]
        //public string WeightType { get; set; }

        //[JsonProperty("entityStateType")]
        //public EntityStateType EntityStateType { get; set; }

        //[JsonProperty("isLocked")]
        //public bool IsLocked { get; set; }

        //[JsonProperty("wareHouseEntryId")]
        //public long? WareHouseEntryId { get; set; }

        //[JsonProperty("declarationStatusId")]
        //public int? DeclarationStatusId { get; set; }

        //[JsonProperty("t1StatusId")]
        //public int? T1StatusId { get; set; }

        //[JsonProperty("declarationDate")]
        //public DateTime? DeclarationDate { get; set; }

        //[JsonProperty("t1Date")]
        //public DateTime? T1Date { get; set; }

        //[JsonProperty("isSevkli")]
        //public bool IsSevkli { get; set; }



        // bilgiler apiden gelince burası kullanılacak 
        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; }

        [JsonProperty("LoaderName")]
        public string LoaderName { get; set; }

        [JsonProperty("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [JsonProperty("SummaryStatementNumber")]
        public string SummaryStatementNumber { get; set; }

        [JsonProperty("AntrepoNumber")]
        public long AntrepoNumber { get; set; }

        [JsonProperty("ContainerNumber")]
        public string ContainerNumber { get; set; }

        [JsonProperty("GoodsNumber")]
        public string GoodsNumber { get; set; }

        [JsonProperty("Genus")]
        public string Genus { get; set; }

        [JsonProperty("Weight")]
        public int Weight { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}