# Quickstart: Create a Python function in Azure using Visual Studio Code

[EXAMPLE: Using the Azure CLI](./demo-azure-cli/README.md)

[EXAMPLE: Using VS Code and Recommended Extensions]()

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
