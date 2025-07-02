using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class EditInteractionVariables
    {
        [JsonProperty("input")]
        public EditInteractionInput Input { get; set; }

        public EditInteractionVariables(EditInteractionInput editInteractionInput)
        {
            Input = editInteractionInput;
        }
    }
}