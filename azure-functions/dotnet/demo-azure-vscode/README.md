# Exercise: Create an Azure Function by using Visual Studio Code

See [Exercise: Create an Azure Function by using Visual Studio Code](https://learn.microsoft.com/en-us/training/modules/develop-azure-functions/5-create-function-visual-studio-code) for more information.

## Prerequisites

Before you begin, make sure you have the following requirements in place:

- An Azure account with an active subscription.

- The [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools#installing) version 4.x.

- [Visual Studio Code](https://code.visualstudio.com/) on one of the [supported platforms](https://code.visualstudio.com/docs/supporting/requirements#_platforms).

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) is the target framework.

```sh
# On macOS => Check what version (if any) of dotnet exists on our local development machine
% dotnet --version
7.0.306

# Install homebrew if it's not already installed - https://brew.sh/

# Update homebrew
% brew update

# Update .NET SDK and Runtime
% brew upgrade --cask dotnet
# OPTIONAL: Install the dotnet cask if necessary
% brew install --cask dotnet-sdk
==> Downloading https://download.visualstudio.microsoft.com/download/pr/1764cd94-29ac-46b2-b308-77d02b47486d/8397cdc3d842a60f062f1a08199a4974/dotnet-sdk-8.0.401-osx-arm64.pkg
################################################################################################################################################################################### 100.0%
==> Installing Cask dotnet-sdk
==> Running installer for dotnet-sdk with sudo; the password may be necessary.
Password:
installer: Package name is Microsoft .NET SDK 8.0.401 (arm64)
installer: Upgrading at base path /
installer: The upgrade was successful.
==> Linking Binary 'dotnet' to '/opt/homebrew/bin/dotnet'
🍺  dotnet-sdk was successfully installed!

# Verify the Installation
% dotnet --version
8.0.401

# BONUS: List .NET SDKs installed on your machine
% dotnet --list-sdks
6.0.400 [/usr/local/share/dotnet/sdk]
7.0.306 [/usr/local/share/dotnet/sdk]
8.0.401 [/usr/local/share/dotnet/sdk]

# BONUS: List .NET runtimes installed on your machine
% dotnet --list-runtimes
Microsoft.AspNetCore.App 6.0.8 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 7.0.9 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 8.0.8 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 6.0.8 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 7.0.9 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 8.0.8 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]

```

- The [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code.

- The [Azure Functions extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions) for Visual Studio Code.

## Create your local project

In this section, you use Visual Studio Code to create a local Azure Functions project in C#. Later in this exercise, you publish your function code to Azure.

In Visual Studio Code open the command palette and search for and run the command `Azure Functions: Create New Project....`

Select the directory location for your project workspace and choose Select. You should either create a new folder or choose an empty folder for the project workspace. Don't choose a project folder that is already part of a workspace.

Provide the following information at the prompts:

- Select a language: `C#`
- Select a .NET runtime: `.NET 8.0 Isolated (LTS)`
- Select a template for your project's first function: `HTTP trigger`
- Provide a function name: `HttpExample`
- Provide a namespace: `My.Function`
- Authorization level: `Anonymous`

Visual Studio Code uses the provided information and generates an Azure Functions project with an HTTP trigger. You can view the local project files in the Explorer.
