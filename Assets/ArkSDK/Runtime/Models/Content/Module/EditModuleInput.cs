using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class EditModuleInput
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("courseId")]
        public string CourseId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("interactions")]
        public string[] Interactions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}