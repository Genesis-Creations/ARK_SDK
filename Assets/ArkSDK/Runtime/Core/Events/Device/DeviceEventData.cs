using ARK.SDK.Models.Device;

namespace ARK.SDK.Core.Events.Device
{
    /// <summary>
    /// Event fired when device ID check succeeds
    /// </summary>
    public class DeviceIdValidatedEventData : BaseEventData
    {
        /// <summary>
        /// Device ID that was checked
        /// </summary>
        public string DeviceId { get; }

        /// <summary>
        /// Response from device ID check
        /// </summary>
        public CheckDeviceIdResponse Response { get; }

        /// <summary>
        /// Whether the device ID is valid
        /// </summary>
        public bool IsValid { get; }

        public DeviceIdValidatedEventData(string deviceId, CheckDeviceIdResponse response, bool isValid)
        {
            DeviceId = deviceId;
            Response = response;
            IsValid = isValid;
        }
    }

    /// <summary>
    /// Event fired when device ID check fails
    /// </summary>
    public class DeviceIdValidationFailedEventData : BaseEventData
    {
        /// <summary>
        /// Device ID that failed validation
        /// </summary>
        public string DeviceId { get; }

        /// <summary>
        /// Error message from the failed validation
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        public DeviceIdValidationFailedEventData(string deviceId, string errorMessage, SDKErrorType errorType)
        {
            DeviceId = deviceId;
            ErrorMessage = errorMessage;
            ErrorType = errorType;
        }
    }
} 