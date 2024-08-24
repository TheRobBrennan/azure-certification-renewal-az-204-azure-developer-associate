# Quickstart: Create a function in Azure with Python using Visual Studio Code

## Configure your environment

Before you begin, you must have the following requirements in place:

- An Azure account with an active subscription. Create an account for free.

- A Python version [supported by Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/supported-languages#languages-by-runtime-version).

- Visual Studio Code on one of the supported platforms.

- The [Python extension](https://marketplace.visualstudio.com/items?itemName=ms-python.python) for Visual Studio Code.

- The [Azure Functions extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions) for Visual Studio Code, version 1.8.1 or later.

- The [Azurite storage emulator extension](https://marketplace.visualstudio.com/items?itemName=Azurite.azurite) for Visual Studio Code. While you can also use an actual Azure Storage account, the article assumes you're using this emulator.
  - See [Use the Azurite emulator for local Azure Storage development](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio-code%2Cblob-storage#install-azurite)

### VS CODE: Install or update Core Tools

In Visual Studio Code, select `F1` to open the command palette, and then search for and run the command `Azure Functions: Install or Update Azure Functions Core Tools`

## Create your local project

In Visual Studio Code, press `F1` to open the command palette and search for and run the command `Azure Functions: Create New Project....`

Choose the directory location for your project workspace and choose `Select`. You should either create a new folder or choose an empty folder for the project workspace. Don't choose a project folder that is already part of a workspace.

Provide the following information at the prompts:

- Select a language for your function project: `Python (Programming Model V2`
- Select a Python interpreter to create a virtual environment: Choose your preferred Python interpreter
- Select a template for your project's first function: `HTTP trigger`
- Provide a function name: `HttpExample`
- Authorization level: `ANONYMOUS`

Visual Studio Code uses the provided information and generates an Azure Functions project with an HTTP trigger. You can view the local project files in the Explorer. The generated `function_app.py` project file contains your functions.

Open the local.settings.json project file and verify that the `AzureWebJobsFeatureFlags` setting has a value of `EnableWorkerIndexing`. This is required for Functions to interpret your project correctly as the Python v2 model when running locally.

In the `local.settings.json` file, update the `AzureWebJobsStorage` setting as in the following example:

```json
"AzureWebJobsStorage": "UseDevelopmentStorage=true",
```

This tells the local Functions host to use the storage emulator for the storage connection currently required by the Python v2 model. When you publish your project to Azure, you need to instead use the default storage account. If you're instead using an Azure Storage account, set your storage account connection string here.

## Start the Azure Storage emulator

In Visual Studio Code, open the command palette, search for and select `Azurite: Start` if it isn't already running.

Check the bottom bar and verify that Azurite emulation services are running. If so, you can now run your function locally.

## Run the function locally

You should be able to use `Run and Debug` to launch the `Attach to Python Azure Function` launch configuration for local debugging in VS Code.

Please consult the [guide](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-python#run-the-function-locally) if you are unable to get the functions app to run on your local environment and double-check the working directories for:

- .vscode/launch.json
- .vscode/tasks.json

Once you have the application running, you should see output similar to:

```sh
Found Python version 3.11.1 (python3).

Azure Functions Core Tools
Core Tools Version:       4.0.5907 Commit hash: N/A +807e89766a92b14fd07b9f0bc2bea1d8777ab209 (64-bit)
Function Runtime Version: 4.834.3.22875

[2024-08-24T06:33:25.223Z] 0.00s - Debugger warning: It seems that frozen modules are being used, which may
[2024-08-24T06:33:25.223Z] 0.00s - make the debugger miss breakpoints. Please pass -Xfrozen_modules=off
[2024-08-24T06:33:25.223Z] 0.00s - to python to disable frozen modules.
[2024-08-24T06:33:25.223Z] 0.00s - Note: Debugging will proceed. Set PYDEVD_DISABLE_FILE_VALIDATION=1 to disable this validation.
[2024-08-24T06:33:25.283Z] Worker process started and initialized.

Functions:

        HttpTrigger:  http://localhost:7071/api/HttpTrigger

For detailed output, run func with --verbose flag.
[2024-08-24T06:33:30.316Z] Host lock lease acquired by instance ID '0000000000000000000000002D9F298A'.

```

You should be able to navigate to the Azure extension and execute your function directly within VS Code:

![https://learn.microsoft.com/en-us/azure/includes/media/functions-run-function-test-local-vs-code/execute-function-now.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-run-function-test-local-vs-code/execute-function-now.png)

When the function executes locally and returns a response, a notification is raised in Visual Studio Code. Information about the function execution is shown in Terminal panel.

With the Terminal panel focused, press Ctrl + C to stop Core Tools and disconnect the debugger.

After you verify that the function runs correctly on your local computer, it's time to use Visual Studio Code to publish the project directly to Azure.

## Sign in to Azure

![https://learn.microsoft.com/en-us/azure/includes/media/functions-sign-in-vs-code/functions-sign-into-azure.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-sign-in-vs-code/functions-sign-into-azure.png)

## Create the function app in Azure

In Visual Studio Code, select `F1` to open the command palette. At the prompt (>), enter and then select `Azure Functions: Create Function App in Azure...`.

At the prompts, provide the following information:

Select subscription: **AUTOMATICALLY SELECTED IF YOU ONLY HAVE ONE**
Enter a globally unique name for the function app: `rbfndemo-python-portal`
Select a runtime stack: `Python 3.11`
Select a location for new resources: `West US`

In the Azure: Activity Log panel, the Azure extension shows the status of individual resources as they're created in Azure.

![https://learn.microsoft.com/en-us/azure/includes/media/functions-publish-project-vscode/resource-activity-log.png](https://learn.microsoft.com/en-us/azure/includes/media/functions-publish-project-vscode/resource-activity-log.png)

When the function app is created, the following related resources are created in your Azure subscription. The resources are named based on the name you entered for your function app.

- A resource group, which is a logical container for related resources. - `rbfndemopythonportal`
- A standard Azure Storage account, which maintains state and other information about your projects. - `rbfndemopythonportal`
- A function app, which provides the environment for executing your function code. A function app lets you group functions as a logical unit for easier management, deployment, and sharing of resources within the same hosting plan. - `rbfndemo-python-portal`
- An Azure App Service plan, which defines the underlying host for your function app. - `ASP-rbfndemo-python-portal-b9da`
- An Application Insights instance that's connected to the function app, and which tracks the use of your functions in the app. - `rbfndemopythonportal`
- A notification is displayed after your function app is created and the deployment package is applied.

Tip: By default, the Azure resources required by your function app are created based on the name you enter for your function app. By default, the resources are created with the function app in the same, new resource group. If you want to customize the names of the associated resources or reuse existing resources, publish the project with advanced create options.
