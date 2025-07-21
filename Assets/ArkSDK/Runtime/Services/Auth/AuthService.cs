using ARK.SDK.Core;
using ARK.SDK.Models.Auth;
using ARK.SDK.Queries.Auth;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ARK.SDK.Services.Auth
{
    public class AuthService
    {
        private readonly GraphQLClient client;

        public AuthService(GraphQLClient client)
        {
            this.client = client;
        }

        public async Task<string> LoginWithMailAndPassowrdAsync(string email, string password)
        {
            var variables = new LoginVariables(email, password);
            string json = await client.ExecuteAsync(AuthQueries.Login, variables, "Login");

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<LoginResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                ARKCache.CacheAuthToken(result.data.Login);

                return result.data.Login.AccessToken;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }

        public async Task<string> LoginWithPinCodeAsync(string pinCode)
        {
            var variables = new LoginWithPinCodeVariables(pinCode);
            string json = await client.ExecuteAsync(AuthQueries.LoginWithPincode, variables, "LoginWithPinCode");

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<LoginWithPinCodeResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                ARKCache.CacheAuthToken(result.data.Login);

                return result.data.Login.AccessToken;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }
    }
}