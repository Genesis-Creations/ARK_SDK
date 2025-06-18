using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class GetActiveUserSessionResponse
    {
        [JsonProperty("activeUserSession")]
        public SessionData ActiveUserSession { get; private set; }
    }
}