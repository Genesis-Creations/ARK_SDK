using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class StepResultData
    {
        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("compliance")]
        public bool Compliance { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}