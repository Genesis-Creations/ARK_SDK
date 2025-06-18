namespace ARK.SDK.Queries.Device
{
    public static class DeviceQueries
    {
        public const string CheckDeviceId = @"
                query Query($deviceId: String!) {
          checkDeviceId(deviceId: $deviceId)
        }";
    }
}