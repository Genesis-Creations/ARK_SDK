using ARK.SDK.Models.Auth;

namespace ARK.SDK.Core.Events.Auth
{
    /// <summary>
    /// Event fired when user successfully logs in
    /// </summary>
    public class LoginSuccessEventData : BaseEventData
    {
        /// <summary>
        /// Login data returned from the server
        /// </summary>
        public LoginData LoginData { get; }

        /// <summary>
        /// Login method used (email/password or pin code)
        /// </summary>
        public string LoginMethod { get; }

        public LoginSuccessEventData(LoginData loginData, string loginMethod)
        {
            LoginData = loginData;
            LoginMethod = loginMethod;
        }
    }

    /// <summary>
    /// Event fired when login attempt fails
    /// </summary>
    public class LoginFailedEventData : BaseEventData
    {
        /// <summary>
        /// Error message from the failed login attempt
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Login method that was attempted
        /// </summary>
        public string LoginMethod { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        public LoginFailedEventData(string errorMessage, string loginMethod, SDKErrorType errorType)
        {
            ErrorMessage = errorMessage;
            LoginMethod = loginMethod;
            ErrorType = errorType;
        }
    }

    /// <summary>
    /// Event fired when user logs out
    /// </summary>
    public class LogoutEventData : BaseEventData
    {
        /// <summary>
        /// Whether the logout was initiated by the user or automatic (e.g., token expiry)
        /// </summary>
        public bool IsUserInitiated { get; }

        public LogoutEventData(bool isUserInitiated = true)
        {
            IsUserInitiated = isUserInitiated;
        }
    }
} 