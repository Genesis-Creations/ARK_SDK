using ARK.SDK.Core;
using ARK.SDK.Core.Events;
using ARK.SDK.Core.Events.Auth;
using ARK.SDK.Services.Auth;
using System.Threading.Tasks;

namespace ARK.SDK.Controllers.Auth
{
    public class AuthController
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        public async Task<string> LoginWithMailAndPassowrdAsync(string email, string password)
        {
            try
            {
                var result = await authService.LoginWithMailAndPassowrdAsync(email, password);
                
                // Dispatch success event
                EventManager.Dispatch(new LoginSuccessEventData(ARKCache.Auth, "Email/Password"));
                
                return result;
            }
            catch (SDKException ex)
            {
                // Dispatch failure event
                EventManager.Dispatch(new LoginFailedEventData(ex.Message, "Email/Password", ex.ErrorType));
                
                throw new SDKException(ex.ErrorType, $"LoginWithMailAndPassowrdAsync failed: {ex.Message}");
            }
        }

        public async Task<string> LoginWithPinCodeAsync(string pinCode)
        {
            try
            {
                var result = await authService.LoginWithPinCodeAsync(pinCode);
                
                // Dispatch success event
                EventManager.Dispatch(new LoginSuccessEventData(ARKCache.Auth, "Pin Code"));
                
                return result;
            }
            catch (SDKException ex)
            {
                // Dispatch failure event
                EventManager.Dispatch(new LoginFailedEventData(ex.Message, "Pin Code", ex.ErrorType));
                
                throw new SDKException(ex.ErrorType, $"LoginWithPinCodeAsync failed: {ex.Message}");
            }
        }

        public void Logout(bool isUserInitiated = true)
        {
            // Clear the cache
            ARKCache.Clear();
            
            // Dispatch logout event
            EventManager.Dispatch(new LogoutEventData(isUserInitiated));
        }
    }
}