# Quickstart: Create a TypeScript function in Azure using Visual Studio Code

See [Quickstart: Create a TypeScript function in Azure using Visual Studio Code](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-typescript?pivots=nodejs-model-v4)

## Configure your environment

```sh
# PREREQUISITES: Must have an Azure account with an active subscription

# PREREQUISITE: Node.js v.18+ required
% node --version
v20.11.1

# PREREQUISITE: Visual Studio Code installed on your development machine

# VS CODE: Install the Azure Functions extension v1.10.4 or above
# https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions

# VS CODE: Install or update Core Tools
# In Visual Studio Code, select F1 to open the command palette, and then search for and run the command Azure Functions: Install or Update Core Tools.
```

## Create your local project

In Visual Studio Code, press `F1` to open the command palette and search for and run the command `Azure Functions: Create New Project....`

Choose the directory location for your project workspace and choose Select. You should either create a new folder or choose an empty folder for the project workspace. Don't choose a project folder that is already part of a workspace.

Provide the following information at the prompts:

- Select a language for your function project: `TypeScript`
- Select a JavaScript programming model: `Model V4`
- Select a template for your project's first function: `HTTP trigger`
- Provide a function name: `HttpExample`

Using this information, Visual Studio Code generates an Azure Functions project with an HTTP trigger. You can view the local project files in the Explorer. To learn more about files that are created, see Azure Functions JavaScript developer guide.

## Run the function locally

Before running the function, you will need to either use or create an Azure Storage Account - or install a local Azure storage emulator.

Please consult the [guide](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-typescript?pivots=nodejs-model-v4#run-the-function-locally) if you are unable to get the functions app to run on your local environment.

Once you have the application running, you should see output similar to:

```sh
Azure Functions Core Tools
Core Tools Version:       4.0.5907 Commit hash: N/A +807e89766a92b14fd07b9f0bc2bea1d8777ab209 (64-bit)
Function Runtime Version: 4.834.3.22875

[2024-08-25T21:49:20.907Z] Debugger listening on ws://127.0.0.1:9229/3e825916-d322-4088-9651-ac9fb3647c76
[2024-08-25T21:49:20.907Z] For help, see: https://nodejs.org/en/docs/inspector
[2024-08-25T21:49:20.964Z] Worker process started and initialized.
[2024-08-25T21:49:20.989Z] Debugger attached.

Functions:

        HttpExample: [GET,POST] http://localhost:7071/api/HttpExample

For detailed output, run func with --verbose flag.
[2024-08-25T21:49:26.044Z] Host lock lease acquired by instance ID '0000000000000000000000002D9F298A'.
```

Use the Azure extension to execute your function within VS Code:

![https://learn.microsoft.com/en-us/azure/includes/media/functions-run-function-test-local-vs-code/execute-function-now.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-run-function-test-local-vs-code/execute-function-now.png)

After executing the function locally, you should see output similar to the following:

```sh
[2024-08-25T21:50:00.954Z] Executing 'Functions.HttpExample' (Reason='This function was programmatically called via the host APIs.', Id=f9cbf4d8-1ead-44e6-b448-d32a8ab70814)
[2024-08-25T21:50:01.020Z] Http function processed request for url "http://localhost:7071/api/httpexample"
[2024-08-25T21:50:01.036Z] Executed 'Functions.HttpExample' (Succeeded, Id=f9cbf4d8-1ead-44e6-b448-d32a8ab70814, Duration=99ms)

```

## Sign in to Azure

![https://learn.microsoft.com/en-us/azure/includes/media/functions-sign-in-vs-code/functions-sign-into-azure.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-sign-in-vs-code/functions-sign-into-azure.png)

## Create the function app in Azure

In Visual Studio Code, select `F1` to open the command palette. At the prompt (>), enter and then select `Azure Functions: Create Function App in Azure`.

At the prompts, provide the following information:

Select subscription: **AUTOMATICALLY SELECTED IF YOU ONLY HAVE ONE**
Enter a globally unique name for the function app: `rbfndemo-typescript-portal`
Select a runtime stack: `Node.js 20 LTS`
Select a location for new resources: `West US`

In the Azure: Activity Log panel, the Azure extension shows the status of individual resources as they're created in Azure.

![https://learn.microsoft.com/en-us/azure/includes/media/functions-publish-project-vscode/resource-activity-log.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-publish-project-vscode/resource-activity-log.png)

When the function app is created, the following related resources are created in your Azure subscription. The resources are named based on the name you entered for your function app.

- A resource group, which is a logical container for related resources. - `rbfndemotypescriptportal`
- A standard Azure Storage account, which maintains state and other information about your projects. - `rbfndemotypescriptportal`
- A function app, which provides the environment for executing your function code. A function app lets you group functions as a logical unit for easier management, deployment, and sharing of resources within the same hosting plan. - `rbfndemo-typescript-portal`
- An Azure App Service plan, which defines the underlying host for your function app. - `ASP-rbfndemo-typescript-portal-c1fa`
- An Application Insights instance that's connected to the function app, and which tracks the use of your functions in the app. - `rbfndemotypescriptportal`
- A notification is displayed after your function app is created and the deployment package is applied.

Tip: By default, the Azure resources required by your function app are created based on the name you enter for your function app. By default, the resources are created with the function app in the same, new resource group. If you want to customize the names of the associated resources or reuse existing resources, publish the project with advanced create options.
