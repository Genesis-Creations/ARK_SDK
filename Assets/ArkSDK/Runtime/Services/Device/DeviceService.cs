using ARK.SDK.Core;
using ARK.SDK.Models.Branding;
using ARK.SDK.Models.Device;
using ARK.SDK.Queries.Device;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ARK.SDK.Services.Device
{
    public class DeviceService
    {
        private readonly GraphQLClient client;

        public DeviceService(GraphQLClient client)
        {
            this.client = client;
        }

        public async Task<CheckDeviceIdResponse> CheckDeviceIdAsync(string deviceId)
        {
            var variables = new CheckDeviceIdVariables(deviceId);
            string json = await client.ExecuteAsync(DeviceQueries.CheckDeviceId);

            try
            {
                var result = JsonConvert.DeserializeObject<GraphQLResponse<CheckDeviceIdResponse>>(json);

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