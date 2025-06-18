using Newtonsoft.Json;

namespace ARK.SDK.Models.Branding
{
    public class BrandingResponse
    {
        [JsonProperty("branding")]
        public BrandingData Branding { get; private set; }
    }
}
