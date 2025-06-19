using Newtonsoft.Json;

namespace ARK.SDK.Models.Auth
{
    public class LoginData
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; private set; }
    }
}