using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class EditModuleVariables
    {
        [JsonProperty("input")]
        public EditModuleInput Input { get; set; }

        public EditModuleVariables(EditModuleInput editModuleInput)
        {
            Input = editModuleInput;
        }
    }
}