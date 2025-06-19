using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class InteractionData
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}