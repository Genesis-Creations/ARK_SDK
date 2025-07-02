using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class InteractionData
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}