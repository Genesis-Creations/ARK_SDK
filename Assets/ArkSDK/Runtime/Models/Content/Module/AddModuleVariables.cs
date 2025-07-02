using Newtonsoft.Json;
using UnityEngine;

namespace ARK.SDK.Models.Content
{
    public class AddModuleVariables
    {
        [JsonProperty("input")]
        public AddModuleInput Input { get; set; }

        public AddModuleVariables(AddModuleInput addModuleInput)
        {
            Input = addModuleInput;
        }
    }
}