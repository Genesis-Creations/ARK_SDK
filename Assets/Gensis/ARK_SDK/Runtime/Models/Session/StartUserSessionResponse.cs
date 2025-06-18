using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class StartUserSessionResponse
    {
        [JsonProperty("startUserSession")]
        public bool StartUserSession { get; private set; }
    }
}