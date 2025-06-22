using Newtonsoft.Json;
using System.Collections.Generic;

namespace ARK.SDK.Models.Session
{
    public class InteractionResultData
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }

        [JsonProperty("completed")]
        public float Completed { get; private set; }

        [JsonProperty("completionRatio")]
        public float CompletionRatio { get; private set; }

        [JsonProperty("compliance")]
        public float Compliance { get; private set; }

        [JsonProperty("complianceRatio")]
        public float ComplianceRatio { get; private set; }
        
        [JsonProperty("duration")]
        public int Duration { get; private set; }
        
        [JsonProperty("score")]
        public float Score { get; private set; }

        [JsonProperty("steps")]
        public List<StepResultData> Steps { get; private set; }

        [JsonProperty("success")]
        public bool Success { get; private set; }

        [JsonProperty("total")]
        public float Total { get; private set; }
    }
}