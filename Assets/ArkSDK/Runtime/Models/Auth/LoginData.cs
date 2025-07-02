using Newtonsoft.Json;

namespace ARK.SDK.Models.Auth
{
    public class LoginData
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}