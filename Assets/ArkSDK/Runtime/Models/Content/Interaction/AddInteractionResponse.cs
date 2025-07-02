using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class AddInteractionResponse
    {
        [JsonProperty("addInteraction")]
        public ModuleData ModuleData { get; private set; }
    }
}