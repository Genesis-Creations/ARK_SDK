using ARK.SDK.Models.Branding;
using ARK.SDK.Models.Session;

namespace ARK.SDK.Core
{
    public static class ARKCache
    {
        public static string AuthToken { get; private set; }
        public static SessionData Session { get; private set; }
        public static BrandingData Branding { get; private set; }

        public static void CacheAuthToken(string token)
        {
            AuthToken = token;
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
            AuthToken = null;
            Session = null;
        }
    }
}