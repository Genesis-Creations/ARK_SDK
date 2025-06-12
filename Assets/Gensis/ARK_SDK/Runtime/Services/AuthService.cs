using ARK.SDK.Core;
using ARK.SDK.Models.Auth;
using ARK.SDK.Queries.Auth;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace ARK.SDK.Services
{
    public class AuthService
    {
        private readonly GraphQLClient client;

        public AuthService(GraphQLClient client)
        {
            this.client = client;
        }

        public async UniTask<string> LoginAsync(string email, string password)
        {
            var variables = new LoginVariables(email, password);
            string json = await client.ExecuteAsync(AuthQueries.Login, variables);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<LoginResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                return result.data.login.accessToken;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }
    }
}