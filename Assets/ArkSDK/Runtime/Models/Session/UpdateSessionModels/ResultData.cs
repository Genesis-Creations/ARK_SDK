using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class UserSessionResult
    {
        [JsonProperty("module")]
        public ModuleResultInput Module { get; set; }

        public UserSessionResult(ModuleResultInput module)
        {
            Module = module;
        }
    }
}