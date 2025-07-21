using ARK.SDK.Core;
using ARK.SDK.Core.Events;
using ARK.SDK.Core.Events.Session;
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
                var result = await sessionService.GetActiveUserSessionAsync();
                
                // Dispatch success event
                EventManager.Dispatch(new ActiveSessionRetrievedEventData(result));
                
                return result;
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
                var result = await sessionService.StartUserSessionAsync(sessionId);
                
                // Dispatch success event
                EventManager.Dispatch(new SessionStartedEventData(result, sessionId));
                
                return result;
            }
            catch (SDKException ex)
            {
                // Dispatch failure event
                EventManager.Dispatch(new SessionStartFailedEventData(ex.Message, sessionId, ex.ErrorType));
                
                throw new SDKException(ex.ErrorType, $"StartUserSessionAsync failed: {ex.Message}");
            }
        }

        public async Task<bool> UpdateUserSessionAsync(string sessionId, UserSessionResultInput userSessionResultInput)
        {
            try
            {
                var result = await sessionService.UpdateUserSessionAsync(sessionId, userSessionResultInput);
                
                // Dispatch success event
                EventManager.Dispatch(new SessionUpdatedEventData(sessionId, result, userSessionResultInput));
                
                return result;
            }
            catch (SDKException ex)
            {
                // Dispatch failure event
                EventManager.Dispatch(new SessionUpdateFailedEventData(ex.Message, sessionId, ex.ErrorType));
                
                throw new SDKException(ex.ErrorType, $"UpdateUserSessionAsync failed: {ex.Message}");
            }
        }
    }
}