using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class EditModuleResponse
    {
        [JsonProperty("editModule")]
        public ModuleData ModuleData { get; private set; }
    }
}