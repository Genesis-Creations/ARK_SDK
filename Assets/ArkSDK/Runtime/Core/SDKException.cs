namespace ARK.SDK.Core
{
    public class SDKException : System.Exception
    {
        public SDKErrorType ErrorType { get; }
        public string ErrorMessage { get; }

        public SDKException(SDKErrorType type, string message) : base(message)
        {
            ErrorType = type;
            ErrorMessage = message;
        }
    }

    public enum SDKErrorType
    {
        NetworkError,
        GraphQLError,
        BadRequest,
        Unauthorized,
        ParsingError,
        InternalError,
        Unknown
    }
}