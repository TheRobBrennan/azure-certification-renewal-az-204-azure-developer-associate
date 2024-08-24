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
