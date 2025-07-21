namespace ARK.SDK.Core.Events.Network
{
    /// <summary>
    /// Event fired when a network request starts
    /// </summary>
    public class NetworkRequestStartedEventData : BaseEventData
    {
        /// <summary>
        /// Endpoint being called
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// Request type (e.g., "Login", "GetSession", etc.)
        /// </summary>
        public string RequestType { get; }

        /// <summary>
        /// HTTP method (GET, POST, etc.)
        /// </summary>
        public string Method { get; }

        public NetworkRequestStartedEventData(string endpoint, string requestType, string method = "POST")
        {
            Endpoint = endpoint;
            RequestType = requestType;
            Method = method;
        }
    }

    /// <summary>
    /// Event fired when a network request completes successfully
    /// </summary>
    public class NetworkRequestSucceededEventData : BaseEventData
    {
        /// <summary>
        /// Endpoint that was called
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// Request type (e.g., "Login", "GetSession", etc.)
        /// </summary>
        public string RequestType { get; }

        /// <summary>
        /// Response code
        /// </summary>
        public long ResponseCode { get; }

        /// <summary>
        /// Response time in milliseconds
        /// </summary>
        public long ResponseTimeMs { get; }

        public NetworkRequestSucceededEventData(string endpoint, string requestType, long responseCode, long responseTimeMs)
        {
            Endpoint = endpoint;
            RequestType = requestType;
            ResponseCode = responseCode;
            ResponseTimeMs = responseTimeMs;
        }
    }

    /// <summary>
    /// Event fired when a network request fails
    /// </summary>
    public class NetworkRequestFailedEventData : BaseEventData
    {
        /// <summary>
        /// Endpoint that was called
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// Request type (e.g., "Login", "GetSession", etc.)
        /// </summary>
        public string RequestType { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Response code (if available)
        /// </summary>
        public long? ResponseCode { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        public NetworkRequestFailedEventData(string endpoint, string requestType, string errorMessage, SDKErrorType errorType, long? responseCode = null)
        {
            Endpoint = endpoint;
            RequestType = requestType;
            ErrorMessage = errorMessage;
            ErrorType = errorType;
            ResponseCode = responseCode;
        }
    }
} 