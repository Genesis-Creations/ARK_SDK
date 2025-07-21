using ARK.SDK.Models.Branding;

namespace ARK.SDK.Core.Events.Branding
{
    /// <summary>
    /// Event fired when branding data is successfully retrieved
    /// </summary>
    public class BrandingRetrievedEventData : BaseEventData
    {
        /// <summary>
        /// Branding data retrieved from server
        /// </summary>
        public BrandingData BrandingData { get; }

        public BrandingRetrievedEventData(BrandingData brandingData)
        {
            BrandingData = brandingData;
        }
    }

    /// <summary>
    /// Event fired when branding data retrieval fails
    /// </summary>
    public class BrandingRetrievalFailedEventData : BaseEventData
    {
        /// <summary>
        /// Error message from the failed branding retrieval
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        public BrandingRetrievalFailedEventData(string errorMessage, SDKErrorType errorType)
        {
            ErrorMessage = errorMessage;
            ErrorType = errorType;
        }
    }
} 