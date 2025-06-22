using Newtonsoft.Json;
using UnityEngine;

namespace ARK.SDK.Models.Result
{
    public class UpdateUserSessionVariables : MonoBehaviour
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("input")]
        public UserSessionResultInputData Input { get; set; }

        public UpdateUserSessionVariables(string sessionId, ModuleResultData moduleResultData)
        {
            SessionId = sessionId;
            Input = new UserSessionResultInputData(moduleResultData);
        }
    }
}