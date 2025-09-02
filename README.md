# ARK SDK for Unity  
![Status](https://img.shields.io/badge/status-active-success)
![Static Badge](https://img.shields.io/badge/release-V1.1.2-red?style=flat&color=red)

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Package Contents](#package-contents)
- [Installation](#installation)
- [Compatibility](#compatibility)
- [Quick Start](#quick-start)
- [Usage Guide](#usage-guide)
  - [Authentication](#authentication)
  - [Session Management](#session-management)
  - [Device Management](#device-management)
  - [Branding](#branding)
  - [Content Management](#content-management)
  - [Event System](#event-system)
- [Samples](#samples)
- [Troubleshooting](#troubleshooting)


## Overview
ARK SDK is a modular GraphQL SDK for Unity that simplifies backend communication, authentication, and state management. It provides a service-based layer to interact with your backend using GraphQL, making it easy to integrate features like user authentication, course management, session handling, and event-driven communication into your Unity projects.
## Features  

| Feature | Description |
|---------|-------------|
| **GraphQL** | Simple, type-safe service layer to interact with your **GraphQL backend**. |
| **Authentication** | Handle **user login, signup, and token management** with minimal setup. |
| **Course Management** | Manage **courses, enrollment, and progress tracking** out-of-the-box. |
| **Session Management** | Maintain **active user sessions**, auto-refresh tokens, and handle expiration events. |
| **Event System** | Subscribe to SDK events like **login success, logout, course updates, or errors** for clean event-driven workflows. |
| **Modular & Extensible** | Add or remove **services** as needed; integrate only what your project requires. |

## Package Contents

After importing the SDK, you’ll see the following structure under `ArkSDK`:

- **Editor/**  
  Unity Editor utilities and inspectors.

- **Runtime/**  
  Core SDK implementation:  
  - `Controllers/` → Handles API logic for **Auth, Branding, Content, Device, Session**.  
  - `Core/` → Central classes (`ARKManager`, `ARKCache`, `GraphQLClient`, `GraphQLError`, etc.).  
  - `Models/` → Data models for each domain.  
  - `Queries/` → GraphQL queries grouped by domain.
  - `Resources/` → Contains required assets (e.g., `ArkSettings`).
  - `Samples/` → Demo scenes and scripts.`

- **Documentation/**  
  SDK documentation and guides.

  
## Installation  

You can install **ARK SDK for Unity** in several ways depending on your workflow:  

### Unity Package Manager (Git URL)  
1. Open **Unity** → `Edit` → `Project Settings` → `Package Manager`.  
2. Click the **+** button → `Add package from git URL...`.  
3. Paste the following:  

```text
https://github.com/Genesis-Creations/ARK_SDK.git?path=Assets/ArkSDK
```

## Compatibility

![Unity](https://img.shields.io/badge/unity-2021.3%2B-blue?logo=unity)
![GraphQL](https://img.shields.io/badge/graphql-compatible-ff69b4?logo=graphql)

- ✅ **Unity**: 2022.3 LTS and newer  
- 📦 Distributed via **Unity Package Manager**

## Quick Start  

Getting started with **ARK SDK for Unity** takes just a few steps.  

---

### 1. Configure the domain 

1. In Unity, create an **ARK Settings** asset:  
   - Right-click in the Project window → `Genesis → ArKSDK → settings`.  
   - Set your **GraphQL backend domain** in the Inspector.  
2. The asset **must** be placed inside a `Resources/Settings` folder.  
   - Example path: `ArkSDK\Runtime\Resources\ArkSettings.asset`  

⚠️ Do not rename or move this asset.  

---

### 2. Initialize and use the SDK

Once ``ArkSettings`` configured, you don’t need to manually initialize anything, **`ARKManager`** automatically loads your settings and manages all controllers.  

Example:  

```csharp
using ARK.SDK.Core;
using UnityEngine;

public class ExampleUsage : MonoBehaviour {
    private async void Start() {
        // Authenticate
         wait ARKManager.Auth.LoginWithMailAndPassowrdAsync(emailInputField.text, passwordInputField.text);
         Debug.Log($"Auth Token : {JsonConvert.SerializeObject(ARKCache.Auth)}");
         

        // Get active session
        await ARKManager.Session.GetActiveUserSessionAsync();
        Debug.Log($"Session Data : {JsonConvert.SerializeObject(ARKCache.Session)}");

        // Subscribe to events
        ARKManager.Events.Subscribe<LoginSuccessEventData>(OnLoginSuccess);
    }
    private void OnLoginSuccess(LoginSuccessEventData eventData) {
        Debug.Log($"User logged in: {eventData.User.Email}");
    }
}
```
## Usage Guide  

The `ARKManager` provides access to all core SDK features through dedicated controllers.  
Below are the most commonly used services and examples.  

---

### Authentication  
Authenticate users with email/password or pincode.  
```csharp
// Login with email + password
var result = await ARKManager.Auth.LoginWithMailAndPassowrdAsync("user@mail.com", "password123");

// Login with pin code
var result = await ARKManager.Auth.LoginWithPinCodeAsync("123456");

// Check cached auth data
Debug.Log($"Token: {ARKCache.Auth?.AccessToken}");
```
### Session Management  
Start, retrieve, or update user sessions.
```csharp
// Get active session
await ARKManager.Session.GetActiveUserSessionAsync();
Debug.Log($"Session: {ARKCache.Session?.Id}");

// Start a new session
await ARKManager.Session.StartUserSessionAsync("session123");

// Update session progress
var moduleResult = new ModuleResultInput { Id = "module123", Duration = 10 };
var userSessionResult = new UserSessionResultInput(moduleResult);
await ARKManager.Session.UpdateUserSessionAsync(ARKCache.Session.Id, userSessionResult);
```


### Device Management  

Validate and manage devices with the SDK.  

```csharp
// Check if a device ID is valid
var response = await ARKManager.Device.CheckDeviceIdAsync("device-12345");
Debug.Log($"Device Valid: {response.CheckDeviceId}");
```
---

### Branding  

Fetch branding data from your backend (e.g., logos, themes, styles).  

```csharp
// Retrieve branding configuration
var response = await ARKManager.Branding.GetBrandingAsync();
Debug.Log($"Branding: {JsonConvert.SerializeObject(response.Branding)}");
```
---

### Content Management  

Manage Interactions, Modules, and Courses directly from Unity.  

#### Add Interaction
```csharp
var input = new AddInteractionInput()
{
    ModuleId = "module-id",
    Name = "Interaction Name",
    DisplayName = "Interaction Display Name",
    Description = "Interaction Description",
    Duration = 120, // seconds
    Score = 100
};

var result = await ARKManager.Content.AddInteractionAsync(input);
Debug.Log($"Interaction Added: {result.InteractionData.Id}");
```
#### Add Module
```csharp
var input = new AddModuleInput()
{
    CourseId = "course-id",
    Name = "Module Name",
    DisplayName = "Module Display Name",
    Description = "Module Description"
};

var result = await ARKManager.Content.AddModuleAsync(input);
Debug.Log($"Module Added: {result.ModuleData.Id}");
```
#### Add Course  
```csharp
var input = new AddCourseInput()
{
    Name = "Course Name",
    DisplayName = "Course Display Name",
    Description = "Course Description",
    Labels = new[] { "label1", "label2" },
    Organization = "org-id",
    IsDemo = false,
    Image = "image-url"
};

var result = await ARKManager.Content.AddCourseAsync(input);
Debug.Log($"Course Added: {result.CourseData.Id}");
```
#### Update Interaction  
```csharp
var input = new EditInteractionInput { Id = "interaction-id", ModuleId = "module-id", Name = "Updated Interaction" };
var result = await ARKManager.Content.EditInteractionAsync(input);
Debug.Log(result.InteractionData.Id);
```
#### Update Module
```csharp
var input = new EditModuleInput { Id = "module-id", CourseId = "course-id", Name = "Updated Module" };
var result = await ARKManager.Content.EditModuleAsync(input);
Debug.Log(result.ModuleData.Id);
```
#### Update Course
```csharp
var input = new EditCourseInput { Id = "course-id", Name = "Updated Name" };
var result = await ARKManager.Content.EditCourseAsync(input);
Debug.Log(result.CourseData.Id);
```
---


### Event System  
React to authentication, session, network, and cache changes.
```csharp
// Subscribe to events
ARKManager.Events.Subscribe<LoginSuccessEventData>(e =>
    Debug.Log($"✅ Login Success: {e.LoginMethod}"));

ARKManager.Events.Subscribe<SessionStartedEventData>(e =>
    Debug.Log($"📘 Session Started: {e.SessionId}"));

// Network events
ARKManager.Events.Subscribe<NetworkRequestFailedEventData>(e =>
    Debug.LogError($"❌ Network Error: {e.ErrorMessage}"));

// Cache events
ARKManager.Events.Subscribe<DataCachedEventData>(e =>
    Debug.Log($"💾 Cached: {e.DataKey}"));

// Unsubscribe when done (e.g., OnDestroy)
ARKManager.Events.Unsubscribe<LoginSuccessEventData>();
```
---

## Samples

The SDK includes a **Sample Package** containing ready-to-use demo scripts under the `ARK.SDK.Demo` namespace.  
Each demo script is a `MonoBehaviour` showcasing how to call and test different API endpoints (e.g., Session, Device, Branding, Content).  

### How to Test
1. Import the **Samples** folder via the Unity Package Manager (`Window > Package Manager > ARK SDK > Samples > All_In_One_Sample > Import`).
2. Open the demo scene
3. Enter Play Mode and interact with the provided UI buttons/fields to trigger API calls.
4. Responses are logged in the Unity **Console** for quick inspection.

> ✅ This is the fastest way to explore and validate all SDK functionalities without writing custom code.

<p>
  <img src="Assets\ArkSDK\Documentation~\Images\sample-screenshot.png" alt="ARK SDK Demo Sample in Play Mode"/>
</p>

## Troubleshooting

This section covers common issues you may encounter while using **ARK SDK for Unity** and how to resolve them.

---

### 1. Missing `ArkSettings.asset`  

**Cause:** The `ArkSettings.asset` file is not in the correct location or is misnamed.  

**Solution:**  
- Ensure the asset is in `ArkSDK\Runtime\Resources`.  
- The asset file must be named exactly `ArkSettings.asset`.  
- Do **not** rename or move it elsewhere.

---

### 2. Wrong Backend Domain  

**Cause:** The domain in `ArkSettings.asset` is incorrect or unreachable.  

**Solution:**  
- Open the `ArkSettings.asset` in the Inspector.  
- Verify that the **GraphQL backend domain** is correct.  
