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

## Run the function locally

In the `Run and Debug` extension, select `Attach to .NET Functions` to run your C# Azure Functions project locally.

Please see [Run the function locally](https://learn.microsoft.com/en-us/training/modules/develop-azure-functions/5-create-function-visual-studio-code) if you are encountering issues.

In the `Terminal` output tab in VS Code, you should see something similar to:

```sh
 *  Executing task: func host start 


Azure Functions Core Tools
Core Tools Version:       4.0.5907 Commit hash: N/A +807e89766a92b14fd07b9f0bc2bea1d8777ab209 (64-bit)
Function Runtime Version: 4.834.3.22875

[2024-08-25T22:36:32.300Z] Found /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/dotnet/demo-azure-vscode/demo-azure-vscode.csproj. Using for user secrets file configuration.
[2024-08-25T22:36:33.919Z] Worker process started and initialized.

Functions:

        HttpExample: [GET,POST] http://localhost:7071/api/HttpExample

For detailed output, run func with --verbose flag.
[2024-08-25T22:36:38.896Z] Host lock lease acquired by instance ID '0000000000000000000000002D9F298A'.

```

With Core Tools running, go to the `Azure: Functions` area. Under `Functions`, expand `Local Project > Functions`. Right-click the `HttpExample` function and choose `Execute Function Now...`

You should see output similar to:

```sh
[2024-08-25T22:39:46.746Z] Executing 'Functions.HttpExample' (Reason='This function was programmatically called via the host APIs.', Id=b8f2ef8b-d021-4545-87e3-1b532e2ce79d)
[2024-08-25T22:39:46.927Z] C# HTTP trigger function processed a request.
[2024-08-25T22:39:46.927Z] Executing OkObjectResult, writing value of type 'System.String'.
[2024-08-25T22:39:46.989Z] Executed 'Functions.HttpExample' (Succeeded, Id=b8f2ef8b-d021-4545-87e3-1b532e2ce79d, Duration=265ms)

```

## Sign in to Azure

If you aren't already signed in, choose the `Azure` icon in the Activity bar, then in the `Azure: Functions` area, choose `Sign in to Azure...`

![https://learn.microsoft.com/en-us/azure/includes/media/functions-sign-in-vs-code/functions-sign-into-azure.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-sign-in-vs-code/functions-sign-into-azure.png)

## Create resources in Azure

In Visual Studio Code, open the command palette and then select `Azure Functions: Create Function App in Azure`

At the prompts, provide the following information:

- Select subscription: **AUTOMATICALLY SELECTED IF YOU ONLY HAVE ONE**
- Enter a globally unique name for the function app: `rbfndemo-dotnet-portal`
- Select a runtime stack: `.NET 8 Isolated`
- Select a location for new resources: `West US`

In the `Azure: Activity Log` panel, the Azure extension shows the status of individual resources as they're created in Azure.

![https://learn.microsoft.com/en-us/azure/includes/media/functions-publish-project-vscode/resource-activity-log.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-publish-project-vscode/resource-activity-log.png)

When the function app is created, the following related resources are created in your Azure subscription. The resources are named based on the name you entered for your function app.

- A resource group, which is a logical container for related resources. - `rbfndemodotnetportal`
- A standard Azure Storage account, which maintains state and other information about your projects. - `rbfndemodotnetportal`
- A function app, which provides the environment for executing your function code. A function app lets you group functions as a logical unit for easier management, deployment, and sharing of resources within the same hosting plan. - `rbfndemo-dotnet-portal`
- An Azure App Service plan, which defines the underlying host for your function app. - `ASP-rbfndemo-dotnet-portal-d925`
- An Application Insights instance that's connected to the function app, and which tracks the use of your functions in the app. - `rbfndemodotnetportal`
- A notification is displayed after your function app is created and the deployment package is applied.

Tip: By default, the Azure resources required by your function app are created based on the name you enter for your function app. By default, the resources are created with the function app in the same, new resource group. If you want to customize the names of the associated resources or reuse existing resources, publish the project with advanced create options.

## Deploy the project to Azure

IMPORTANT: Deploying to an existing function app always overwrites the contents of that app in Azure.

In the command palette, enter and then select `Azure Functions: Deploy to Function App`.

Select the function app you just created. When prompted about overwriting previous deployments, select `Deploy` to deploy your function code to the new function app resource.

Once you have successfully deployed to Azure, you should see `Output` similar to the following:

```sh
3:52:33 PM rbfndemo-dotnet-portal: HTTP Trigger Urls:
  HttpExample: https://rbfndemo-dotnet-portal.azurewebsites.net/api/httpexample
```

## Run the function in Azure

Back in the `Resources` area in the side bar, expand your subscription, your new function app, and `Functions`. Right-click the `HttpExample` function and choose `Execute Function Now...`

![https://learn.microsoft.com/en-us/azure/includes/media/functions-vs-code-run-remote/execute-function-now.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-vs-code-run-remote/execute-function-now.png)

Example URL for the HttpExample function - [https://rbfndemo-dotnet-portal.azurewebsites.net/api/httpexample](https://rbfndemo-dotnet-portal.azurewebsites.net/api/httpexample)
