using ARK.SDK.Core;
using ARK.SDK.Core.Events;
using ARK.SDK.Services.Events;
using System;

namespace ARK.SDK.Controllers.Events
{
    /// <summary>
    /// Controller layer for event management. Provides the public API for events.
    /// </summary>
    public class EventController
    {
        private readonly EventService eventService;

        public EventController(EventService eventService)
        {
            this.eventService = eventService;
        }

        /// <summary>
        /// Subscribe to an event of type T
        /// </summary>
        /// <typeparam name="T">Event type to subscribe to</typeparam>
        /// <param name="listener">Callback function to execute when event is raised</param>
        public void Subscribe<T>(Action<T> listener) where T : BaseEventData
        {
            try
            {
                eventService.Subscribe(listener);
            }
            catch (Exception ex)
            {
                throw new SDKException(SDKErrorType.InternalError, $"Failed to subscribe to event {typeof(T).Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// Unsubscribe from an event of type T
        /// </summary>
        /// <typeparam name="T">Event type to unsubscribe from</typeparam>
        /// <param name="listener">Callback function to remove</param>
        public void Unsubscribe<T>(Action<T> listener) where T : BaseEventData
        {
            try
            {
                eventService.Unsubscribe(listener);
            }
            catch (Exception ex)
            {
                throw new SDKException(SDKErrorType.InternalError, $"Failed to unsubscribe from event {typeof(T).Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// Clear all event subscriptions
        /// </summary>
        public void ClearAll()
        {
            try
            {
                eventService.ClearAll();
            }
            catch (Exception ex)
            {
                throw new SDKException(SDKErrorType.InternalError, $"Failed to clear all event subscriptions: {ex.Message}");
            }
        }

        /// <summary>
        /// Clear all subscriptions for a specific event type
        /// </summary>
        /// <typeparam name="T">Event type to clear</typeparam>
        public void Clear<T>() where T : BaseEventData
        {
            try
            {
                eventService.Clear<T>();
            }
            catch (Exception ex)
            {
                throw new SDKException(SDKErrorType.InternalError, $"Failed to clear event subscriptions for {typeof(T).Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// Get the number of subscribers for a specific event type
        /// </summary>
        /// <typeparam name="T">Event type to check</typeparam>
        /// <returns>Number of subscribers</returns>
        public int GetSubscriberCount<T>() where T : BaseEventData
        {
            try
            {
                return eventService.GetSubscriberCount<T>();
            }
            catch (Exception ex)
            {
                throw new SDKException(SDKErrorType.InternalError, $"Failed to get subscriber count for {typeof(T).Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// Dispatch an event to all subscribers (for advanced use cases)
        /// </summary>
        /// <typeparam name="T">Event type to dispatch</typeparam>
        /// <param name="eventData">Event data to send to subscribers</param>
        public void Dispatch<T>(T eventData) where T : BaseEventData
        {
            try
            {
                eventService.Dispatch(eventData);
            }
            catch (Exception ex)
            {
                throw new SDKException(SDKErrorType.InternalError, $"Failed to dispatch event {typeof(T).Name}: {ex.Message}");
            }
        }
    }
} 