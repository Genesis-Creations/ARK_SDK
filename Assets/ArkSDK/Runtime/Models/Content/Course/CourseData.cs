
using Newtonsoft.Json;
using System;

namespace ARK.SDK.Models.Content
{
    public class CourseData
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("expireDate")]
        public DateTime ExpireDate { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isDemo")]
        public bool IsDemo { get; set; }

        [JsonProperty("isSuspended")]
        public bool IsSuspended { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("licenseCount")]
        public int LicenseCount { get; set; }

        [JsonProperty("modulesCount")]
        public int ModulesCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sessionsCount")]
        public int SessionsCount { get; set; }
    }
}
