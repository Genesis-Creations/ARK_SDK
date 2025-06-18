using ARK.SDK.Controllers;
using ARK.SDK.Core;
using ARK.SDK.Services.Auth;
using UnityEngine;

namespace ARK.SDK
{
    public static class ARKSDK
    {
        public static bool IsInitialized { get; private set; }

        public static GraphQLClient Client { get; private set; }
        public static AuthController Auth { get; private set; }

        public static void Initialize(string endpoint)
        {
            if (IsInitialized)
            {
                Debug.Log("ARKSDK is already initialized.");
                return;
            }
            Client = new GraphQLClient(endpoint);
            var authService = new AuthService(Client);
            Auth = new AuthController(authService);

            IsInitialized = true;
        }
    }
}