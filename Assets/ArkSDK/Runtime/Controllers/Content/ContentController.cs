using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using ARK.SDK.Services.Content;
using System.Threading.Tasks;

namespace ARK.SDK.Controllers.Content
{
    public class ContentController
    {
        private readonly ContentService contentService;

        public ContentController(ContentService contentService)
        {
            this.contentService = contentService;
        }

        public async Task<AddCourseResponse> AddCourseAsync(AddCourseInput addCourseInput)
        {
            try
            {
                return await contentService.AddCourseAsync(addCourseInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"AddCourseAsync failed: {ex.Message}");
            }
        }
    }
}