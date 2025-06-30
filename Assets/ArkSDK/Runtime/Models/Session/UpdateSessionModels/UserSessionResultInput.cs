using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class UserSessionResultInput
    {
        [JsonProperty("results")]
        public UserSessionResult Results { get; set; }

        public UserSessionResultInput(ModuleResultInput module)
        {
            Results = new UserSessionResult(module);
        }
    }
}