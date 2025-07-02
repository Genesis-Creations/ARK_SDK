using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class ModuleData
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        //[JsonProperty("interactions")]
        //public string[] Interactions { get; set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}