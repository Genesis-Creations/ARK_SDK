using Newtonsoft.Json;

namespace ARK.SDK.Models.Content
{
    public class AddModuleInput
    {
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