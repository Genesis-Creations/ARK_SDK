# ARK SDK Event System

A simple, scalable, and easy-to-use event system for the ARK SDK that allows you to listen to various SDK operations and respond accordingly.

**Access the event system through `ARKManager.Events` - the centralized entry point for all SDK functionality.**

The event system follows the same Service-Controller architecture pattern as other ARK SDK components:
- **EventService** - Core event management logic
- **EventController** - Public API layer with error handling
- **ARKManager.Events** - Convenient access through the main SDK manager

## Features

- **Type-safe events** - All events are strongly typed with specific event data
- **Easy subscription/unsubscription** - Simple API for managing event listeners
- **Automatic error handling** - Events continue to work even if one listener fails
- **Memory leak prevention** - Built-in cleanup mechanisms
- **Comprehensive coverage** - Events for auth, sessions, network, cache, content, device, and branding operations

## Quick Start

### 1. Subscribe to Events

```csharp
using ARK.SDK.Core;
using ARK.SDK.Core.Events.Auth;

// Subscribe to login success events
ARKManager.Events.Subscribe<LoginSuccessEventData>(OnLoginSuccess);

private void OnLoginSuccess(LoginSuccessEventData eventData)
{
    Debug.Log($"User logged in via {eventData.LoginMethod}");
    Debug.Log($"Access token: {eventData.LoginData.AccessToken}");
}
```

### 2. Don't Forget to Unsubscribe

```csharp
private void OnDestroy()
{
    // Always unsubscribe to prevent memory leaks
    ARKManager.Events.Unsubscribe<LoginSuccessEventData>(OnLoginSuccess);
}
```

## Available Events

### Authentication Events
- `LoginSuccessEventData` - Fired when login succeeds
- `LoginFailedEventData` - Fired when login fails  
- `LogoutEventData` - Fired when user logs out

### Session Events
- `SessionStartedEventData` - Fired when session starts successfully
- `SessionStartFailedEventData` - Fired when session start fails
- `SessionUpdatedEventData` - Fired when session is updated
- `SessionUpdateFailedEventData` - Fired when session update fails
- `ActiveSessionRetrievedEventData` - Fired when active session is retrieved

### Network Events
- `NetworkRequestStartedEventData` - Fired when any network request starts
- `NetworkRequestSucceededEventData` - Fired when network request succeeds
- `NetworkRequestFailedEventData` - Fired when network request fails

### Cache Events
- `DataCachedEventData` - Fired when data is cached
- `CacheClearedEventData` - Fired when cache is cleared

### Content Events
- `ContentOperationSuccessEventData` - Fired when content operations succeed
- `ContentOperationFailedEventData` - Fired when content operations fail
- `CoursesRetrievedEventData` - Fired when courses are retrieved

### Device Events
- `DeviceIdValidatedEventData` - Fired when device ID validation succeeds
- `DeviceIdValidationFailedEventData` - Fired when device ID validation fails

### Branding Events
- `BrandingRetrievedEventData` - Fired when branding data is retrieved
- `BrandingRetrievalFailedEventData` - Fired when branding retrieval fails

## Best Practices

1. **Always unsubscribe** in `OnDestroy()` to prevent memory leaks
2. **Use specific event types** rather than listening to everything
3. **Keep event handlers lightweight** - don't perform heavy operations
4. **Handle errors gracefully** in your event handlers
5. **Use events for decoupling** - let different parts of your app react independently

## Example Usage

```csharp
void Start()
{
    ARKManager.Events.Subscribe<LoginSuccessEventData>(OnLoginSuccess);
    ARKManager.Events.Subscribe<LoginFailedEventData>(OnLoginFailed);
}

private void OnLoginSuccess(LoginSuccessEventData eventData)
{
    ShowSuccessMessage($"Welcome! Logged in via {eventData.LoginMethod}");
}

private void OnLoginFailed(LoginFailedEventData eventData)
{
    ShowErrorMessage($"Login failed: {eventData.ErrorMessage}");
}

private void OnDestroy()
{
    ARKManager.Events.Unsubscribe<LoginSuccessEventData>(OnLoginSuccess);
    ARKManager.Events.Unsubscribe<LoginFailedEventData>(OnLoginFailed);
}
```

See `EventSystemDemo.cs` in the Samples~ folder for a complete working example.