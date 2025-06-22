using Newtonsoft.Json;

namespace ARK.SDK.Models.Result
{
    public class ModuleResultData
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }

        [JsonProperty("duration")]
        public int Duration { get; private set; }

        [JsonProperty("interactions")]
        public InteractionResultData[] Interactions { get; private set; }

        [JsonProperty("score")]
        public float Score { get; private set; }

        [JsonProperty("url")]
        public string Url { get; private set; }
    }
}