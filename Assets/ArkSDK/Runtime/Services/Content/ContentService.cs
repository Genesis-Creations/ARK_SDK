using ARK.SDK.Core;
using ARK.SDK.Models.Content;
using ARK.SDK.Queries.Content;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ARK.SDK.Services.Content
{
    public class ContentService
    {
        private readonly GraphQLClient client;

        public ContentService(GraphQLClient client)
        {
            this.client = client;
        }

        public async Task<AddCourseResponse> AddCourseAsync(AddCourseInput addCourseInput)
        {
            var variables = new AddCourseVariables(addCourseInput);
            string json = await client.ExecuteAsync(ContentQueries.AddCourse, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<AddCourseResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<EditCourseResponse> EditCourseAsync(EditCourseInput editCourseInput)
        {
            var variables = new EditCourseVariables(editCourseInput);
            string json = await client.ExecuteAsync(ContentQueries.EditCourse, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<EditCourseResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<AddModuleResponse> AddModuleAsync(AddModuleInput addModuleInput)
        {
            var variables = new AddModuleVariables(addModuleInput);
            string json = await client.ExecuteAsync(ContentQueries.AddModule, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<AddModuleResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<EditModuleResponse> EditModuleAsync(EditModuleInput editModuleInput)
        {
            var variables = new EditModuleVariables(editModuleInput);
            string json = await client.ExecuteAsync(ContentQueries.EditModule, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<EditModuleResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<AddInteractionResponse> AddInteractionAsync(AddInteractionInput addInteractionInput)
        {
            var variables = new AddInteractionVariables(addInteractionInput);
            string json = await client.ExecuteAsync(ContentQueries.AddInteraction, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<AddInteractionResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<EditInteractionResponse> EditInteractionAsync(EditInteractionInput editInteractionInput)
        {
            var variables = new EditInteractionVariables(editInteractionInput);
            string json = await client.ExecuteAsync(ContentQueries.EditInteraction, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<EditInteractionResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }
    }
}