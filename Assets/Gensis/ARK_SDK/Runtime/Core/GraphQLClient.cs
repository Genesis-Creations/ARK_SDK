using Cysharp.Threading.Tasks;
using System.Text;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace ARK.SDK.Core
{
    public class GraphQLClient
    {
        private readonly string endpoint;
        private bool enableLogging = true;

        public GraphQLClient(string endpoint)
        {
            this.endpoint = endpoint;
        }

        // Make the 'variables' parameter optional (defaults to null)
        public async UniTask<string> ExecuteAsync(string query, object variables = null)
        {
            var payload = new { query, variables };
            string jsonPayload = JsonConvert.SerializeObject(payload);

            if (enableLogging)
                Debug.Log($"GraphQL Request:\n{jsonPayload}");

            using var request = new UnityWebRequest(endpoint, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(ARKCache.AuthToken))
                request.SetRequestHeader("Authorization", $"Bearer {ARKCache.AuthToken}");

            return await SendRequestAsync(request);
        }

        private UniTask<string> SendRequestAsync(UnityWebRequest request)
        {
            var tcs = new UniTaskCompletionSource<string>();
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