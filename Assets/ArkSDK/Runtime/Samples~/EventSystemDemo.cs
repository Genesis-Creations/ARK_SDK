using ARK.SDK.Core;
using ARK.SDK.Core.Events.Auth;
using ARK.SDK.Core.Events.Session;
using ARK.SDK.Core.Events.Network;
using ARK.SDK.Core.Events.Cache;
using UnityEngine;
using UnityEngine.UI;

namespace ARK.SDK.Samples
{
    /// <summary>
    /// Demo script showing how to use the ARK SDK Event System
    /// </summary>
    public class EventSystemDemo : MonoBehaviour
    {
        [Header("UI References")]
        public Button loginButton;
        public Button logoutButton;
        public Button startSessionButton;
        public InputField emailInput;
        public InputField passwordInput;
        public Text eventLogText;
        
        private void Start()
        {
            // Subscribe to all auth events
            ARKManager.Events.Subscribe<LoginSuccessEventData>(OnLoginSuccess);
            ARKManager.Events.Subscribe<LoginFailedEventData>(OnLoginFailed);
            ARKManager.Events.Subscribe<LogoutEventData>(OnLogout);
            
            // Subscribe to session events
            ARKManager.Events.Subscribe<SessionStartedEventData>(OnSessionStarted);
            ARKManager.Events.Subscribe<SessionStartFailedEventData>(OnSessionStartFailed);
            ARKManager.Events.Subscribe<SessionUpdatedEventData>(OnSessionUpdated);
            ARKManager.Events.Subscribe<ActiveSessionRetrievedEventData>(OnActiveSessionRetrieved);
            
            // Subscribe to network events
            ARKManager.Events.Subscribe<NetworkRequestStartedEventData>(OnNetworkRequestStarted);
            ARKManager.Events.Subscribe<NetworkRequestSucceededEventData>(OnNetworkRequestSucceeded);
            ARKManager.Events.Subscribe<NetworkRequestFailedEventData>(OnNetworkRequestFailed);
            
            // Subscribe to cache events
            ARKManager.Events.Subscribe<DataCachedEventData>(OnDataCached);
            ARKManager.Events.Subscribe<CacheClearedEventData>(OnCacheCleared);
            
            // Setup UI
            SetupUI();
            
            LogEvent("Event System Demo Started - All events subscribed");
        }
        
        private void SetupUI()
        {
            if (loginButton != null)
                loginButton.onClick.AddListener(OnLoginButtonClicked);
                
            if (logoutButton != null)
                logoutButton.onClick.AddListener(OnLogoutButtonClicked);
                
            if (startSessionButton != null)
                startSessionButton.onClick.AddListener(OnStartSessionButtonClicked);
        }
        
        #region UI Event Handlers
        
        private async void OnLoginButtonClicked()
        {
            if (emailInput == null || passwordInput == null) return;
            
            string email = emailInput.text;
            string password = passwordInput.text;
            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                LogEvent("Please enter both email and password");
                return;
            }
            
            try
            {
                await ARKManager.Auth.LoginWithMailAndPassowrdAsync(email, password);
            }
            catch (System.Exception ex)
            {
                LogEvent($"Login exception (handled by events): {ex.Message}");
            }
        }
        
        private void OnLogoutButtonClicked()
        {
            ARKManager.Auth.Logout();
        }
        
        private async void OnStartSessionButtonClicked()
        {
            try
            {
                // This is just a demo - in real usage you'd have a proper session ID
                await ARKManager.Session.StartUserSessionAsync("demo-session-id");
            }
            catch (System.Exception ex)
            {
                LogEvent($"Session start exception (handled by events): {ex.Message}");
            }
        }
        
        #endregion
        
        #region Auth Event Handlers
        
        private void OnLoginSuccess(LoginSuccessEventData eventData)
        {
            LogEvent($"🟢 LOGIN SUCCESS via {eventData.LoginMethod} at {eventData.Timestamp:HH:mm:ss}");
            LogEvent($"   User ID: {eventData.LoginData?.UserId}");
            LogEvent($"   Access Token: {eventData.LoginData?.AccessToken?.Substring(0, 10)}...");
        }
        
        private void OnLoginFailed(LoginFailedEventData eventData)
        {
            LogEvent($"🔴 LOGIN FAILED via {eventData.LoginMethod} at {eventData.Timestamp:HH:mm:ss}");
            LogEvent($"   Error: {eventData.ErrorMessage}");
            LogEvent($"   Error Type: {eventData.ErrorType}");
        }
        
        private void OnLogout(LogoutEventData eventData)
        {
            LogEvent($"🟡 LOGOUT at {eventData.Timestamp:HH:mm:ss}");
            LogEvent($"   User Initiated: {eventData.IsUserInitiated}");
        }
        
        #endregion
        
        #region Session Event Handlers
        
        private void OnSessionStarted(SessionStartedEventData eventData)
        {
            LogEvent($"🟢 SESSION STARTED at {eventData.Timestamp:HH:mm:ss}");
            LogEvent($"   Session ID: {eventData.SessionId}");
        }
        
        private void OnSessionStartFailed(SessionStartFailedEventData eventData)
        {
            LogEvent($"🔴 SESSION START FAILED at {eventData.Timestamp:HH:mm:ss}");
            LogEvent($"   Session ID: {eventData.SessionId}");
            LogEvent($"   Error: {eventData.ErrorMessage}");
        }
        
        private void OnSessionUpdated(SessionUpdatedEventData eventData)
        {
            LogEvent($"🟢 SESSION UPDATED at {eventData.Timestamp:HH:mm:ss}");
            LogEvent($"   Session ID: {eventData.SessionId}");
            LogEvent($"   Success: {eventData.IsSuccess}");
        }
        
        private void OnActiveSessionRetrieved(ActiveSessionRetrievedEventData eventData)
        {
            LogEvent($"🟢 ACTIVE SESSION RETRIEVED at {eventData.Timestamp:HH:mm:ss}");
        }
        
        #endregion
        
        #region Network Event Handlers
        
        private void OnNetworkRequestStarted(NetworkRequestStartedEventData eventData)
        {
            LogEvent($"🔵 NETWORK REQUEST STARTED: {eventData.RequestType} to {eventData.Endpoint}");
        }
        
        private void OnNetworkRequestSucceeded(NetworkRequestSucceededEventData eventData)
        {
            LogEvent($"🟢 NETWORK REQUEST SUCCESS: {eventData.RequestType} ({eventData.ResponseTimeMs}ms)");
        }
        
        private void OnNetworkRequestFailed(NetworkRequestFailedEventData eventData)
        {
            LogEvent($"🔴 NETWORK REQUEST FAILED: {eventData.RequestType}");
            LogEvent($"   Error: {eventData.ErrorMessage}");
        }
        
        #endregion
        
        #region Cache Event Handlers
        
        private void OnDataCached(DataCachedEventData eventData)
        {
            LogEvent($"💾 DATA CACHED: {eventData.DataType} - {eventData.DataKey}");
        }
        
        private void OnCacheCleared(CacheClearedEventData eventData)
        {
            if (eventData.IsFullClear)
            {
                LogEvent($"🗑️ FULL CACHE CLEARED");
            }
            else
            {
                LogEvent($"🗑️ CACHE CLEARED: {eventData.DataType}");
            }
        }
        
        #endregion
        
        #region Utility Methods
        
        private void LogEvent(string message)
        {
            Debug.Log($"[EventSystemDemo] {message}");
            
            if (eventLogText != null)
            {
                eventLogText.text += $"{System.DateTime.Now:HH:mm:ss} - {message}\n";
                
                // Keep only the last 20 lines
                string[] lines = eventLogText.text.Split('\n');
                if (lines.Length > 20)
                {
                    eventLogText.text = string.Join("\n", lines, lines.Length - 20, 20);
                }
            }
        }
        
        #endregion
        
        private void OnDestroy()
        {
            // Unsubscribe from all events to prevent memory leaks
            ARKManager.Events.Unsubscribe<LoginSuccessEventData>(OnLoginSuccess);
            ARKManager.Events.Unsubscribe<LoginFailedEventData>(OnLoginFailed);
            ARKManager.Events.Unsubscribe<LogoutEventData>(OnLogout);
            
            ARKManager.Events.Unsubscribe<SessionStartedEventData>(OnSessionStarted);
            ARKManager.Events.Unsubscribe<SessionStartFailedEventData>(OnSessionStartFailed);
            ARKManager.Events.Unsubscribe<SessionUpdatedEventData>(OnSessionUpdated);
            ARKManager.Events.Unsubscribe<ActiveSessionRetrievedEventData>(OnActiveSessionRetrieved);
            
            ARKManager.Events.Unsubscribe<NetworkRequestStartedEventData>(OnNetworkRequestStarted);
            ARKManager.Events.Unsubscribe<NetworkRequestSucceededEventData>(OnNetworkRequestSucceeded);
            ARKManager.Events.Unsubscribe<NetworkRequestFailedEventData>(OnNetworkRequestFailed);
            
            ARKManager.Events.Unsubscribe<DataCachedEventData>(OnDataCached);
            ARKManager.Events.Unsubscribe<CacheClearedEventData>(OnCacheCleared);
            
            LogEvent("Event System Demo Destroyed - All events unsubscribed");
        }
    }
} 