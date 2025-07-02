using ARK.SDK.Models.Content;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ARK.SDK.Models.Session
{
    public class SessionData
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }

        [JsonProperty("isTraining")]
        public bool IsTraining { get; private set; }

        [JsonProperty("courses")]
        public List<CourseData> Courses { get; private set; }

        [JsonProperty("modules")]
        public List<ModuleData> Modules { get; private set; }

        [JsonProperty("interactions")]
        public List<InteractionData> Interactions { get; private set; }
    }
}