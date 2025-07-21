using System;

namespace ARK.SDK.Core.Events
{
    /// <summary>
    /// Base class for all ARK SDK event data
    /// </summary>
    public abstract class BaseEventData
    {
        /// <summary>
        /// Timestamp when the event was created
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Unique identifier for this event instance
        /// </summary>
        public string EventId { get; }

        protected BaseEventData()
        {
            Timestamp = DateTime.UtcNow;
            EventId = Guid.NewGuid().ToString();
        }
    }
} 