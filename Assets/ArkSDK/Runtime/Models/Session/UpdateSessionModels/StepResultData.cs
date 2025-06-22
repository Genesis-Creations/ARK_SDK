using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class StepResultData
    {
        [JsonProperty("completed")]
        public bool Completed { get; private set; }

        [JsonProperty("compliance")]
        public bool Compliance { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }
    }
}