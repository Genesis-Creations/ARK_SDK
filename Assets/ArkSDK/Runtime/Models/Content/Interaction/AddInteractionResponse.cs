using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class AddInteractionResponse
    {
        [JsonProperty("addInteraction")]
        public InteractionData InteractionData { get; private set; }
    }
}