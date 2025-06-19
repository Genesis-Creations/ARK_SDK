using ARK.SDK.Core;
using ARK.SDK.Models.Session;
using ARK.SDK.Queries.Session;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ARK.SDK.Services.Session
{
    public class SessionService
    {
        private readonly GraphQLClient client;

        public SessionService(GraphQLClient client)
        {
            this.client = client;
        }

        public async Task<GetActiveUserSessionResponse> GetActiveUserSessionAsync()
        {
            string json = await client.ExecuteAsync(SessionQueries.GetActiveUserSession);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<GetActiveUserSessionResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                ARKCache.CacheSession(result.data.ActiveUserSession);

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<StartUserSessionResponse> StartUserSessionAsync(string sessionId)
        {
            var variables = new StartUserSessionVariables(sessionId);
            string json = await client.ExecuteAsync(SessionQueries.StartUserSession, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<StartUserSessionResponse>>(json);

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