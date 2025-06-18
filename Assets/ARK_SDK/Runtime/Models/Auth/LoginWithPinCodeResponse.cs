using Newtonsoft.Json;

namespace ARK.SDK.Models.Auth
{
    public class LoginWithPinCodeResponse
    {
        [JsonProperty("loginWithPincode")]
        public LoginData Login { get; private set; }
    }
}