using Newtonsoft.Json;
using System.Collections.Generic;

namespace ARK.SDK.Models.Session
{
    public class InteractionResultData
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("completed")]
        public float Completed { get; set; }

        [JsonProperty("completionRatio")]
        public float CompletionRatio { get; set; }

        [JsonProperty("compliance")]
        public float Compliance { get; set; }

        [JsonProperty("complianceRatio")]
        public float ComplianceRatio { get; set; }
        
        [JsonProperty("duration")]
        public int Duration { get; set; }
        
        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("steps")]
        public List<StepResultData> Steps { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("total")]
        public float Total { get; set; }
    }
}