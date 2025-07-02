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
        }

        public static void CacheSession(SessionData session)
        {
            Session = session;
        }
        public static void CacheBranding(BrandingData branding)
        {
            Branding = branding;
        }

        public static void Clear()
        {
            Auth = null;
            Session = null;
        }
    }
}