using Newtonsoft.Json;

namespace EasyTracking.Datas {
    public class DateTimeResponse : BaseResponse {

        [JsonProperty("getDateTimeModel")]
        public GetDateTimeModel GetDateTimeModel { get; set; }
    }
}
