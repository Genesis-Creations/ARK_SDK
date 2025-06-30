using Newtonsoft.Json;
using UnityEngine;

namespace ARK.SDK.Models.Session
{
    public class UpdateUserSessionVariables
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("input")]
        public UserSessionResultInput Input { get; set; }

        public UpdateUserSessionVariables(string sessionId, UserSessionResultInput userSessionResultInput)
        {
            SessionId = sessionId;
            Input = userSessionResultInput;
        }
    }
}