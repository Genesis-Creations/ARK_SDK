using ARK.SDK.Core.Events;
using ARK.SDK.Core.Events.Network;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace ARK.SDK.Core
{
    public class GraphQLClient
    {
        private readonly string endpoint;

        public GraphQLClient(string endpoint)
        {
            this.endpoint = endpoint;
        }

        // Make the 'variables' parameter optional (defaults to null)
        public async Task<string> ExecuteAsync(string query, object variables = null, string requestType = "GraphQL")
        {
            var stopwatch = Stopwatch.StartNew();
            
            // Dispatch request started event
            EventManager.Dispatch(new NetworkRequestStartedEventData(endpoint, requestType));
            
            var payload = new { query, variables };
            string jsonPayload = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            using var request = new UnityWebRequest(endpoint, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            if (ARKCache.Auth != null)
                request.SetRequestHeader("Authorization", $"Bearer {ARKCache.Auth.AccessToken}");

            try
            {
                var result = await SendRequestAsync(request);
                stopwatch.Stop();
                
                // Dispatch success event
                EventManager.Dispatch(new NetworkRequestSucceededEventData(
                    endpoint, 
                    requestType, 
                    request.responseCode, 
                    stopwatch.ElapsedMilliseconds
                ));
                
                return result;
            }
            catch (SDKException ex)
            {
                stopwatch.Stop();
                
                // Dispatch failure event
                EventManager.Dispatch(new NetworkRequestFailedEventData(
                    endpoint, 
                    requestType, 
                    ex.Message, 
                    ex.ErrorType, 
                    request.responseCode
                ));
                
                throw;
            }
        }

        private Task<string> SendRequestAsync(UnityWebRequest request)
        {
            var tcs = new TaskCompletionSource<string>();
            var op = request.SendWebRequest();

            op.completed += _ =>
            {
                if (request.result != UnityWebRequest.Result.Success)
                {
                    tcs.TrySetException(new SDKException(SDKErrorType.NetworkError, request.error));
                }
                else if ((int)request.responseCode >= 400)
                {
                    var errorType = request.responseCode switch
                    {
                        400 => SDKErrorType.BadRequest,
                        401 => SDKErrorType.Unauthorized,
                        _ => SDKErrorType.Unknown
                    };

                    tcs.TrySetException(new SDKException(errorType, $"HTTP {request.responseCode}: {request.downloadHandler.text}"));
                }
                else
                {
                    tcs.TrySetResult(request.downloadHandler.text);
                }
            };

            return tcs.Task;
        }
    }
}