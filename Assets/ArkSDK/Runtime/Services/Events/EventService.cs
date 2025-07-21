using ARK.SDK.Core.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ARK.SDK.Services.Events
{
    /// <summary>
    /// Service layer for event management. Handles the core event logic.
    /// </summary>
    public class EventService
    {
        private readonly Dictionary<Type, List<Delegate>> eventListeners = new Dictionary<Type, List<Delegate>>();

        /// <summary>
        /// Subscribe to an event of type T
        /// </summary>
        /// <typeparam name="T">Event type to subscribe to</typeparam>
        /// <param name="listener">Callback function to execute when event is raised</param>
        public void Subscribe<T>(Action<T> listener) where T : BaseEventData
        {
            var eventType = typeof(T);
            
            if (!eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType] = new List<Delegate>();
            }
            
            eventListeners[eventType].Add(listener);
        }

        /// <summary>
        /// Unsubscribe from an event of type T
        /// </summary>
        /// <typeparam name="T">Event type to unsubscribe from</typeparam>
        /// <param name="listener">Callback function to remove</param>
        public void Unsubscribe<T>(Action<T> listener) where T : BaseEventData
        {
            var eventType = typeof(T);
            
            if (eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType].Remove(listener);
                
                // Clean up empty lists
                if (eventListeners[eventType].Count == 0)
                {
                    eventListeners.Remove(eventType);
                }
            }
        }

        /// <summary>
        /// Dispatch an event to all subscribers
        /// </summary>
        /// <typeparam name="T">Event type to dispatch</typeparam>
        /// <param name="eventData">Event data to send to subscribers</param>
        public void Dispatch<T>(T eventData) where T : BaseEventData
        {
            var eventType = typeof(T);
            
            if (eventListeners.ContainsKey(eventType))
            {
                var listeners = eventListeners[eventType];
                
                // Create a copy of the list to prevent modification during iteration
                var listenersCopy = new List<Delegate>(listeners);
                
                foreach (var listener in listenersCopy)
                {
                    try
                    {
                        ((Action<T>)listener)?.Invoke(eventData);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Error in event listener for {eventType.Name}: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Clear all event subscriptions
        /// </summary>
        public void ClearAll()
        {
            eventListeners.Clear();
        }

        /// <summary>
        /// Clear all subscriptions for a specific event type
        /// </summary>
        /// <typeparam name="T">Event type to clear</typeparam>
        public void Clear<T>() where T : BaseEventData
        {
            var eventType = typeof(T);
            
            if (eventListeners.ContainsKey(eventType))
            {
                eventListeners.Remove(eventType);
            }
        }

        /// <summary>
        /// Get the number of subscribers for a specific event type
        /// </summary>
        /// <typeparam name="T">Event type to check</typeparam>
        /// <returns>Number of subscribers</returns>
        public int GetSubscriberCount<T>() where T : BaseEventData
        {
            var eventType = typeof(T);
            return eventListeners.ContainsKey(eventType) ? eventListeners[eventType].Count : 0;
        }
    }
} 