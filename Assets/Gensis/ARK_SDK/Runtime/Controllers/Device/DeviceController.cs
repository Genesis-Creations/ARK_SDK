using ARK.SDK.Core;
using ARK.SDK.Models.Device;
using ARK.SDK.Models.Session;
using ARK.SDK.Services.Device;
using ARK.SDK.Services.Session;
using Cysharp.Threading.Tasks;

namespace ARK.SDK.Controllers.Device
{
    public class DeviceController
    {
        private readonly DeviceService deviceService;

        public DeviceController(DeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public async UniTask<CheckDeviceIdResponse> CheckDeviceIdAsync(string deviceId)
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