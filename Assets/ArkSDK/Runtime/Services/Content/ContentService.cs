using ARK.SDK.Core;
using ARK.SDK.Models.Auth;
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
    }
}