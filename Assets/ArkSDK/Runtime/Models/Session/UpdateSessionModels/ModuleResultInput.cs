using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class ModuleResultInput
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("duration")]
        public int Duration { get;  set; }

        [JsonProperty("interactions")]
        public InteractionResultData[] Interactions { get;  set; }

        [JsonProperty("score")]
        public float Score { get;  set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}