using ARK.SDK.Controllers.Auth;
using ARK.SDK.Controllers.Branding;
using ARK.SDK.Controllers.Content;
using ARK.SDK.Controllers.Device;
using ARK.SDK.Controllers.Events;
using ARK.SDK.Controllers.Session;
using ARK.SDK.Core.Events;
using ARK.SDK.Services.Auth;
using ARK.SDK.Services.Branding;
using ARK.SDK.Services.Content;
using ARK.SDK.Services.Device;
using ARK.SDK.Services.Events;
using ARK.SDK.Services.Session;
using UnityEngine;

namespace ARK.SDK.Core
{
    public static class ARKManager
    {
        private static ArkSettings arkSettings;

        private static GraphQLClient client;

        private static AuthController authController;

        private static SessionController sessionController;

        private static DeviceController deviceController;

        private static BrandingController brandingController;

        private static ContentController contentController;

        private static EventController eventController;

        private static bool IsInitialized = false;

        static ARKManager()
        {
            if (!IsInitialized)
            {
                Initialize();
            }
        }

        private static void Initialize()
        {
            if (arkSettings == null)
            {
                arkSettings = ArkSettings.GetOrCreateSettings(); // Initialize the settings
            }


            //arkSettings = Resources.Load<ArkSettings>("Settings/ArkSettings");

            if (arkSettings == null)
            {
                Debug.LogError("Failed to load arkSettings from Resources.");
                return;
            }
            else
            {
                IsInitialized = true;
            }
        }

        private static GraphQLClient Client
        {
            get
            {
                if (client == null)
                {
                    if (arkSettings == null)
                    {
                        Debug.LogError("GraphQLSettings ScriptableObject is not assigned.");
                        return null;
                    }

                    client = new GraphQLClient(arkSettings.GraphQLURL);
                }
                return client;
            }
        }

        // Lazy initialization for Controllers
        public static AuthController Auth
        {
            get
            {
                if (authController == null)
                {
                    var authService = new AuthService(Client);
                    authController = new AuthController(authService);
                }
                return authController;
            }
        }

        public static SessionController Session
        {
            get
            {
                if (sessionController == null)
                {
                    var sessionService = new SessionService(Client);
                    sessionController = new SessionController(sessionService);
                }
                return sessionController;
            }
        }

        public static DeviceController Device
        {
            get
            {
                if (deviceController == null)
                {
                    var deviceService = new DeviceService(Client);
                    deviceController = new DeviceController(deviceService);
                }
                return deviceController;
            }
        }

        public static BrandingController Branding
        {
            get
            {
                if (brandingController == null)
                {
                    var brandingService = new BrandingService(Client);
                    brandingController = new BrandingController(brandingService);
                }
                return brandingController;
            }
        }

        public static ContentController Content
        {
            get
            {
                if (contentController == null)
                {
                    var contentService = new ContentService(Client);
                    contentController = new ContentController(contentService);
                }
                return contentController;
            }
        }

        public static EventController Events
        {
            get
            {
                if (eventController == null)
                {
                    var eventService = EventManager.GetEventService();
                    eventController = new EventController(eventService);
                }
                return eventController;
            }
        }
    }
}