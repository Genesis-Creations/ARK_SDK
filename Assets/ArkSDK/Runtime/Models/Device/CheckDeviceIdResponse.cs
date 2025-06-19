using Newtonsoft.Json;

namespace ARK.SDK.Models.Device
{
    public class CheckDeviceIdResponse
    {
        [JsonProperty("checkDeviceId")]
        public bool CheckDeviceId { get; private set; }
    }
}