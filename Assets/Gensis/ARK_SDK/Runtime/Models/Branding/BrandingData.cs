using Newtonsoft.Json;
using System.Collections.Generic;

namespace ARK.SDK.Models.Branding
{
    public class BrandingData
    {
        [JsonProperty("customColor")]
        public string CustomColor { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("logoBgColor")]
        public string LogoBgColor { get; private set; }
        [JsonProperty("primaryColor")]
        public string PrimaryColor { get; private set; }
        [JsonProperty("secondaryColor")]
        public string SecondaryColor { get; private set; }
    }
}