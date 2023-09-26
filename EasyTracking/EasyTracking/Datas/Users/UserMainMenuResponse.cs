using Newtonsoft.Json;
using System.Collections.Generic;

namespace EasyTracking.Datas.Users {
    public class UserMainMenuResponse : BaseResponse {
        [JsonProperty("adminMainMenuModels")]
        public List<UserMainMenu> UserMainMenus { get; set; }
    }
}
