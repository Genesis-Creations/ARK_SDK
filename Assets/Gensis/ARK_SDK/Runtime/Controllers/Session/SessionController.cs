using ARK.SDK.Core;
using ARK.SDK.Models.Session;
using ARK.SDK.Services.Session;
using Cysharp.Threading.Tasks;

namespace ARK.SDK.Controllers.Session
{
    public class SessionController
    {
        private readonly SessionService sessionService;

        public SessionController(SessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public async UniTask<GetActiveUserSessionResponse> GetActiveUserSessionAsync()
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

        public async UniTask<StartUserSessionResponse> StartUserSessionAsync(string sessionId)
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
    }
}