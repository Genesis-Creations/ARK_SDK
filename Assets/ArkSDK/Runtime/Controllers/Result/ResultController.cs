using ARK.SDK.Core;
using ARK.SDK.Models.Result;
using ARK.SDK.Services.Result;
using System.Threading.Tasks;

namespace ARK.SDK.Controllers.Result
{
    public class ResultController
    {
        private readonly ResultService resultService;

        public ResultController(ResultService resultService)
        {
            this.resultService = resultService;
        }

        public async Task<bool> UpdateUserSessionAsync(string sessionId, ModuleResultData moduleResultData)
        {
            try
            {
                return await resultService.UpdateUserSessionAsync(sessionId, moduleResultData);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"UpdateUserSessionAsync failed: {ex.Message}");
            }
        }
    }
}