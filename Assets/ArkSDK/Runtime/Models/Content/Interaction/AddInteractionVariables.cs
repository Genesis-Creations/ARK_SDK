using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class AddInteractionVariables
    {
        [JsonProperty("input")]
        public AddInteractionInput Input { get; set; }

        public AddInteractionVariables(AddInteractionInput addInteractionInput)
        {
            Input = addInteractionInput;
        }
    }
}
