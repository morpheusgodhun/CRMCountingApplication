using Newtonsoft.Json;
using System;

namespace EasyTracking.Datas {
    public class GetDateTimeModel {

        [JsonProperty("serverDateTime")]
        public DateTime ServerDateTime { get; set; }
    }
}
