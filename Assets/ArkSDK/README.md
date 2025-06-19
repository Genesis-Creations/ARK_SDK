# ARK SDK for Unity

ARK SDK is a modular **GraphQL SDK** for Unity, designed to handle authentication, backend interactions, and state management. It provides an easy-to-use service layer to interact with your backend via GraphQL, supporting actions like **login**, **course management**, and **user authentication**.

## Features

- **Authentication**: Log in and manage user sessions.
- **GraphQL Queries**: Send queries to interact with your backend.
- **Modular**: Easily extendable for other GraphQL operations.

## Requirements

- Unity **2022.3.0** or later.
- **UniTask**: For efficient async task handling.
- **Newtonsoft.Json**: For JSON serialization.

## Installation

To add the ARK SDK to your Unity project, follow these steps:

### 1. **Add the SDK to Your Project**

#### Option 1: Using GitHub (recommended for UPM-based dependencies)
Add the following line to your project's **`Packages/manifest.json`** under the `dependencies` section:

```json
{
  "dependencies": {
    "com.genesiscreations.arksdk": "https://github.com/Genesis-Creations/ARK_SDK.git"
  }
}
