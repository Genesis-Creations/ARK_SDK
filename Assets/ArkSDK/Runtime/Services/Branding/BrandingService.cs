using ARK.SDK.Core;
using ARK.SDK.Models.Branding;
using ARK.SDK.Queries.Branding;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

namespace ARK.SDK.Services.Branding
{
    public class BrandingService
    {
        private readonly GraphQLClient client;

        public BrandingService(GraphQLClient client)
        {
            this.client = client;
        }

        public async UniTask<BrandingResponse> BrandingAsync()
        {
            string json = await client.ExecuteAsync(BrandingQueries.Branding);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<BrandingResponse>>(json);

                if (result.errors != null && result.errors.Count > 0)
                {
                    string gqlError = result.errors[0].message;
                    throw new SDKException(SDKErrorType.GraphQLError, gqlError);
                }

                ARKCache.CacheBranding(result.data.Branding);

                return result.data;
            }
            catch (JsonException ex)
            {
                throw new SDKException(SDKErrorType.ParsingError, "Invalid server response format: " + ex.Message);
            }
        }
    }
}