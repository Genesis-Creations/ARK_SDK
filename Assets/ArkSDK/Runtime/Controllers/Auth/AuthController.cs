using ARK.SDK.Core;
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

        public async Task<string> LoginAsync(string email, string password)
        {
            try
            {
                return await authService.LoginAsync(email, password);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"LoginAsync failed: {ex.Message}");
            }
        }

        public async Task<string> LoginWithPinCodeAsync(string pinCode)
        {
            try
            {
                return await authService.LoginWithPinCodeAsync(pinCode);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"LoginWithPinCodeAsync failed: {ex.Message}");
            }
        }
    }
}