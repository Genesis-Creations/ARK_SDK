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

        public async Task<EditCourseResponse> EditCourseAsync(EditCourseInput editCourseInput)
        {
            try
            {
                return await contentService.EditCourseAsync(editCourseInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"EditCourseAsync failed: {ex.Message}");
            }
        }

        public async Task<AddModuleResponse> AddModuleAsync(AddModuleInput addModuleInput)
        {
            try
            {
                return await contentService.AddModuleAsync(addModuleInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"AddModuleAsync failed: {ex.Message}");
            }
        }

        public async Task<EditModuleResponse> EditModuleAsync(EditModuleInput editModuleInput)
        {
            try
            {
                return await contentService.EditModuleAsync(editModuleInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"EditModuleAsync failed: {ex.Message}");
            }
        }

        public async Task<AddInteractionResponse> AddInteractionAsync(AddInteractionInput addInteractionInput)
        {
            try
            {
                return await contentService.AddInteractionAsync(addInteractionInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"AddInteractionAsync failed: {ex.Message}");
            }
        }

        public async Task<EditInteractionResponse> EditInteractionAsync(EditInteractionInput editInteractionInput)
        {
            try
            {
                return await contentService.EditInteractionAsync(editInteractionInput);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"EditInteractionAsync failed: {ex.Message}");
            }
        }
    }
}