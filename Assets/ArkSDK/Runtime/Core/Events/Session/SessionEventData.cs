using ARK.SDK.Models.Session;

namespace ARK.SDK.Core.Events.Session
{
    /// <summary>
    /// Event fired when a user session is started
    /// </summary>
    public class SessionStartedEventData : BaseEventData
    {
        /// <summary>
        /// Session data returned from the server
        /// </summary>
        public StartUserSessionResponse SessionData { get; }

        /// <summary>
        /// Session ID that was started
        /// </summary>
        public string SessionId { get; }

        public SessionStartedEventData(StartUserSessionResponse sessionData, string sessionId)
        {
            SessionData = sessionData;
            SessionId = sessionId;
        }
    }

    /// <summary>
    /// Event fired when session start fails
    /// </summary>
    public class SessionStartFailedEventData : BaseEventData
    {
        /// <summary>
        /// Error message from the failed session start
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Session ID that failed to start
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        public SessionStartFailedEventData(string errorMessage, string sessionId, SDKErrorType errorType)
        {
            ErrorMessage = errorMessage;
            SessionId = sessionId;
            ErrorType = errorType;
        }
    }

    /// <summary>
    /// Event fired when a user session is updated
    /// </summary>
    public class SessionUpdatedEventData : BaseEventData
    {
        /// <summary>
        /// Session ID that was updated
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// Whether the update was successful
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Session result data that was sent
        /// </summary>
        public UserSessionResultInput SessionResult { get; }

        public SessionUpdatedEventData(string sessionId, bool isSuccess, UserSessionResultInput sessionResult)
        {
            SessionId = sessionId;
            IsSuccess = isSuccess;
            SessionResult = sessionResult;
        }
    }

    /// <summary>
    /// Event fired when session update fails
    /// </summary>
    public class SessionUpdateFailedEventData : BaseEventData
    {
        /// <summary>
        /// Error message from the failed session update
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Session ID that failed to update
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        public SessionUpdateFailedEventData(string errorMessage, string sessionId, SDKErrorType errorType)
        {
            ErrorMessage = errorMessage;
            SessionId = sessionId;
            ErrorType = errorType;
        }
    }

    /// <summary>
    /// Event fired when an active user session is retrieved
    /// </summary>
    public class ActiveSessionRetrievedEventData : BaseEventData
    {
        /// <summary>
        /// Active session data
        /// </summary>
        public GetActiveUserSessionResponse SessionData { get; }

        public ActiveSessionRetrievedEventData(GetActiveUserSessionResponse sessionData)
        {
            SessionData = sessionData;
        }
    }
} 