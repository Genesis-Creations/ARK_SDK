using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class AddModuleResponse
    {
        [JsonProperty("addModule")]
        public ModuleData ModuleData { get; private set; }
    }
}