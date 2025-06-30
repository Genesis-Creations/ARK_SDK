using ARK.SDK.Core;
using ARK.SDK.Models.Branding;
using ARK.SDK.Models.Session;
using ARK.SDK.Services.Branding;
using ARK.SDK.Services.Session;
using System.Threading.Tasks;

namespace ARK.SDK.Controllers.Branding
{
    public class BrandingController
    {
        private readonly BrandingService brandingService;

        public BrandingController(BrandingService brandingService)
        {
            this.brandingService = brandingService;
        }

        public async Task<BrandingResponse> GetBrandingAsync()
        {
            try
            {
                return await brandingService.GetBrandingAsync();
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"BrandingAsync failed: {ex.Message}");
            }
        }
    }
}