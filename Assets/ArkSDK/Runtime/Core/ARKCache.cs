using ARK.SDK.Core.Events;
using ARK.SDK.Core.Events.Cache;
using ARK.SDK.Models.Auth;
using ARK.SDK.Models.Branding;
using ARK.SDK.Models.Session;

namespace ARK.SDK.Core
{
    public static class ARKCache
    {
        public static LoginData Auth { get; private set; }
        public static SessionData Session { get; private set; }
        public static BrandingData Branding { get; private set; }

        public static void CacheAuthToken(LoginData loginData)
        {
            Auth = loginData;
            EventManager.Dispatch(new DataCachedEventData("Auth", "LoginData"));
        }

        public static void CacheSession(SessionData session)
        {
            Session = session;
            EventManager.Dispatch(new DataCachedEventData("Session", "SessionData"));
        }
        
        public static void CacheBranding(BrandingData branding)
        {
            Branding = branding;
            EventManager.Dispatch(new DataCachedEventData("Branding", "BrandingData"));
        }

        public static void Clear()
        {
            Auth = null;
            Session = null;
            EventManager.Dispatch(new CacheClearedEventData());
        }

        public static void ClearAuth()
        {
            Auth = null;
            EventManager.Dispatch(new CacheClearedEventData("Auth"));
        }

        public static void ClearSession()
        {
            Session = null;
            EventManager.Dispatch(new CacheClearedEventData("Session"));
        }

        public static void ClearBranding()
        {
            Branding = null;
            EventManager.Dispatch(new CacheClearedEventData("Branding"));
        }
    }
}