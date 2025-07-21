using ARK.SDK.Services.Events;
using System;

namespace ARK.SDK.Core.Events
{
    /// <summary>
    /// Internal event manager for the ARK SDK. Used internally by SDK components to dispatch events.
    /// Public access should be through ARKManager.Events (EventController).
    /// </summary>
    internal static class EventManager
    {
        private static EventService eventService;

        static EventManager()
        {
            eventService = new EventService();
        }

        /// <summary>
        /// Get the internal event service instance (used by ARKManager)
        /// </summary>
        internal static EventService GetEventService()
        {
            return eventService;
        }

        /// <summary>
        /// Dispatch an event to all subscribers (for internal SDK use)
        /// </summary>
        /// <typeparam name="T">Event type to dispatch</typeparam>
        /// <param name="eventData">Event data to send to subscribers</param>
        internal static void Dispatch<T>(T eventData) where T : BaseEventData
        {
            eventService.Dispatch(eventData);
        }
    }
} 