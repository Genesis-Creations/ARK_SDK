using ARK.SDK.Core;
using ARK.SDK.Models.Result;
using ARK.SDK.Queries.Result;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ARK.SDK.Services.Result
{
    public class ResultService
    {
        private readonly GraphQLClient client;

        public ResultService(GraphQLClient client)
        {
            this.client = client;
        }

        public async Task<bool> UpdateUserSessionAsync(string sessionId, ModuleResultData moduleResultData)
        {
            var variables = new UpdateUserSessionVariables(sessionId, moduleResultData);
            string json = await client.ExecuteAsync(ResultQueries.UpdateUserSession, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<bool>>(json);

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