using Newtonsoft.Json;

namespace ARK.SDK.Models.Auth
{
    public class LoginResponse
    {
        [JsonProperty("login")]
        public LoginData Login { get; private set; }
    }
}