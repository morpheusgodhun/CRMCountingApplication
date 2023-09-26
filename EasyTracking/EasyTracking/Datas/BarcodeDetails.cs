using Newtonsoft.Json;
namespace EasyTracking.Datas {
    namespace EasyTracking.Datas {
        public class BarcodeDetails {
            [JsonProperty("customerName")]
            public string CaptionName { get; set; }
            [JsonProperty("loaderName")]
            public string FormName { get; set; }
            [JsonProperty("registerDate")]
            public int Id { get; set; }
            [JsonProperty("summaryStatementNumber")]
            public bool IsAdd { get; set; }
            [JsonProperty("antrepoNumber")]
            public bool IsDelete { get; set; }
            [JsonProperty("containerNumber")]
            public bool IsExport { get; set; }
            [JsonProperty("goodsNumber")]
            public bool IsPrint { get; set; }
            [JsonProperty("genus")]
            public string Genus { get; set; }
            [JsonProperty("weight")]
            public int Weight { get; set; }
            [JsonProperty("count")]
            public int RequiredCount { get; set; }
        }
    }
}
