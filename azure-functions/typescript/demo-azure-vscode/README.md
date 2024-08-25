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
