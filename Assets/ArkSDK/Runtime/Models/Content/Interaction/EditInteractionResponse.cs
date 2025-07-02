using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class EditInteractionResponse
    {
        [JsonProperty("editInteraction")]
        public InteractionData InteractionData { get; private set; }
    }
}
