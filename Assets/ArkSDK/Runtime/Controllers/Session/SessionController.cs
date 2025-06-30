using ARK.SDK.Core;
using ARK.SDK.Models.Session;
using ARK.SDK.Services.Session;
using System.Threading.Tasks;

namespace ARK.SDK.Controllers.Session
{
    public class SessionController
    {
        private readonly SessionService sessionService;

        public SessionController(SessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public async Task<GetActiveUserSessionResponse> GetActiveUserSessionAsync()
        {
            try
            {
                return await sessionService.GetActiveUserSessionAsync();
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"GetActiveUserSessionAsync failed: {ex.Message}");
            }
        }

        public async Task<StartUserSessionResponse> StartUserSessionAsync(string sessionId)
        {
            try
            {
                return await sessionService.StartUserSessionAsync(sessionId);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"StartUserSessionAsync failed: {ex.Message}");
            }
        }

        public async Task<bool> UpdateUserSessionAsync(string sessionId, UserSessionResultInput userSessionResultInput)
        {
            try
            {
                return await sessionService.UpdateUserSessionAsync(sessionId, userSessionResultInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"UpdateUserSessionAsync failed: {ex.Message}");
            }
        }
    }
}