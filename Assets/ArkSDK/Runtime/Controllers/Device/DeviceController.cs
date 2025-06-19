using ARK.SDK.Core;
using ARK.SDK.Models.Device;
using ARK.SDK.Services.Device;
using System.Threading.Tasks;

namespace ARK.SDK.Controllers.Device
{
    public class DeviceController
    {
        private readonly DeviceService deviceService;

        public DeviceController(DeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public async Task<CheckDeviceIdResponse> CheckDeviceIdAsync(string deviceId)
        {
            try
            {
                return await deviceService.CheckDeviceIdAsync(deviceId);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"CheckDeviceIdAsync failed: {ex.Message}");
            }
        }
    }
}