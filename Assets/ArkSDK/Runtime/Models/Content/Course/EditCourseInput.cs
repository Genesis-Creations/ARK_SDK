using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class EditCourseInput
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isDemo")]
        public bool IsDemo { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("modules")]
        public string[] Modules { get; set; } // Modules IDs, Optional, not in the original query

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organization")]
        public string Organization { get; set; } // Organization ID
    }
}