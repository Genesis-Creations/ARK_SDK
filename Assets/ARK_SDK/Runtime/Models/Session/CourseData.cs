using Newtonsoft.Json;

namespace ARK.SDK.Models.Session
{
    public class CourseData
    {
        [JsonProperty("_id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}