namespace ARK.SDK.Core.Events.Content
{
    /// <summary>
    /// Base class for all content-related events
    /// </summary>
    public abstract class ContentEventData : BaseEventData
    {
        /// <summary>
        /// Type of content operation (Course, Module, Interaction)
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Operation performed (Add, Edit, Delete, Get)
        /// </summary>
        public string Operation { get; }

        protected ContentEventData(string contentType, string operation)
        {
            ContentType = contentType;
            Operation = operation;
        }
    }

    /// <summary>
    /// Event fired when content operation succeeds
    /// </summary>
    public class ContentOperationSuccessEventData : ContentEventData
    {
        /// <summary>
        /// ID of the content item
        /// </summary>
        public string ContentId { get; }

        /// <summary>
        /// Additional data from the operation
        /// </summary>
        public object ResponseData { get; }

        public ContentOperationSuccessEventData(string contentType, string operation, string contentId, object responseData = null)
            : base(contentType, operation)
        {
            ContentId = contentId;
            ResponseData = responseData;
        }
    }

    /// <summary>
    /// Event fired when content operation fails
    /// </summary>
    public class ContentOperationFailedEventData : ContentEventData
    {
        /// <summary>
        /// Error message from the failed operation
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// SDK error type
        /// </summary>
        public SDKErrorType ErrorType { get; }

        /// <summary>
        /// ID of the content item (if available)
        /// </summary>
        public string ContentId { get; }

        public ContentOperationFailedEventData(string contentType, string operation, string errorMessage, SDKErrorType errorType, string contentId = null)
            : base(contentType, operation)
        {
            ErrorMessage = errorMessage;
            ErrorType = errorType;
            ContentId = contentId;
        }
    }

    /// <summary>
    /// Event fired when courses are retrieved
    /// </summary>
    public class CoursesRetrievedEventData : ContentEventData
    {
        /// <summary>
        /// Number of courses retrieved
        /// </summary>
        public int CourseCount { get; }

        /// <summary>
        /// Courses data
        /// </summary>
        public object CoursesData { get; }

        public CoursesRetrievedEventData(int courseCount, object coursesData)
            : base("Course", "Get")
        {
            CourseCount = courseCount;
            CoursesData = coursesData;
        }
    }
} 