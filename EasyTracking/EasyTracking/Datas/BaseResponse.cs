using Newtonsoft.Json;

namespace EasyTracking.Datas {
    public class BaseResponse {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}