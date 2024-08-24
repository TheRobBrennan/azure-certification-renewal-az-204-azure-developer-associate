# EXAMPLE: Using VS Code

Please see [Quickstart: Create a Python function in Azure from the command line](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-python?tabs=macos%2Cbash%2Cazure-cli%2Cbrowser) for detailed instructions.

In this article, you use command-line tools to create a Python function that responds to HTTP requests. After testing the code locally, you deploy it to the serverless environment of Azure Functions.

This article uses the Python v2 programming model for Azure Functions, which provides a decorator-based approach for creating functions. To learn more about the Python v2 programming model, see the Developer Reference Guide

## Configure your local environment

Before you begin, you must have the following requirements in place:

- An Azure account with an active subscription. Create an account for free.

- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) version 2.4 or later.

- A Python version [supported by Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/supported-languages#languages-by-runtime-version).

- The Azurite storage emulator. While you can also use an actual Azure Storage account, the article assumes you're using this emulator.
  - See [Use the Azurite emulator for local Azure Storage development](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio-code%2Cblob-storage#install-azurite)

### Install the Azure Functions Core Tools

```sh
# PREREQUISITE: Install the Azure CLI tool on macOS
% brew update && brew install azure-cli
rob@prism javascript % brew update && brew install azure-cli
==> Updating Homebrew...
Already up-to-date.
Warning: azure-cli 2.63.0 is already installed and up-to-date.
To reinstall 2.63.0, run:
  brew reinstall azure-cli

# PREREQUISITE: Install the Azure Functions Core Tools on macOS
#   => Install homebrew if it's not already installed - https://brew.sh/
% brew tap azure/functions
% brew install azure-functions-core-tools@4

# VERIFY: Make sure your version of Core Tools is at least 4.0.5530
% func --version

```

### Create and activate a virtual environment

```sh
# Create a folder that will contain your Azure Functions project
% mkdir demo-azure-cli

# Create and activate a virtual environment on macOS
% python3 -m venv .venv
% source .venv/bin/activate
(.venv) % 

```

## Create a local function

In Azure Functions, a function project is a container for one or more individual functions that each responds to a specific trigger. All functions in a project share the same local and hosting configurations.

```sh
# Navigate to the appropriate directory
% cd azure-functions/python/demo-azure-cli

# Make sure you have activated your virtual environment
% source .venv/bin/activate

# Initialize a Python Azure Functions Project
% func init --python
Found Python version 3.11.1 (python3).
The new Python programming model is generally available. Learn more at https://aka.ms/pythonprogrammingmodel
Writing requirements.txt
Writing .funcignore
Writing function_app.py
.gitignore already exists. Skipped!
Writing host.json
Writing local.settings.json
Writing /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/python/demo-azure-cli/.vscode/extensions.json

# Add a function named HttpExample as a public function using an HTTP Trigger
% func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"
Appending to /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/python/demo-azure-cli/function_app.py
The function "HttpExample" was created successfully from the "HTTP trigger" template.

```
