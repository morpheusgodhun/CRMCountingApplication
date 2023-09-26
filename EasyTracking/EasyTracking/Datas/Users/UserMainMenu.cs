using Newtonsoft.Json;

namespace EasyTracking.Datas.Users {
    public class UserMainMenu {

        [JsonProperty("captionName")]
        public string CaptionName { get; set; }
        [JsonProperty("formName")]
        public string FormName { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("isAdd")]
        public bool IsAdd { get; set; }
        [JsonProperty("isDelete")]
        public bool IsDelete { get; set; }
        [JsonProperty("isExport")]
        public bool IsExport { get; set; }
        [JsonProperty("isPrint")]
        public bool IsPrint { get; set; }
        [JsonProperty("isShow")]
        public bool IsShow { get; set; }
        [JsonProperty("isUpdate")]
        public bool IsUpdate { get; set; }
        [JsonProperty("parentId")]
        public int? ParentId { get; set; }
        [JsonProperty("windowFormName")]
        public string WindowFormName { get; set; }

    }
}