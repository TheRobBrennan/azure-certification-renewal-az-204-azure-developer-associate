# Quickstart: Create a TypeScript function in Azure from the command line

See [Quickstart: Create a TypeScript function in Azure from the command line](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-typescript?tabs=macos%2Cazure-cli%2Cbrowser&pivots=nodejs-model-v4)

## Configure your local environment

```sh
# PREREQUISITE: Install the Azure Functions Core Tools on macOS
#   => Install homebrew if it's not already installed - https://brew.sh/
% brew tap azure/functions
% brew install azure-functions-core-tools@4

# PREREQUISITE: Install the Azure CLI tool on macOS
% brew update && brew install azure-cli
rob@prism javascript % brew update && brew install azure-cli
==> Updating Homebrew...
Already up-to-date.
Warning: azure-cli 2.63.0 is already installed and up-to-date.
To reinstall 2.63.0, run:
  brew reinstall azure-cli

```

## Create a local function project

```sh
# Create a folder for our function project
% mkdir demo-azure-cli

# Navigate to the folder containing our function project
% cd demo-azure-cli

# Initialize an Azure Functions project using TypeScript
% func init --typescript
The new Node.js programming model is generally available. Learn more at https://aka.ms/AzFuncNodeV4
Writing package.json
Writing .funcignore
Writing tsconfig.json
Writing .gitignore
Writing host.json
Writing local.settings.json
Writing /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/typescript/demo-azure-cli/.vscode/extensions.json
Running 'npm install'...%

# Add HttpExample as a public function using an HTTP Trigger
% func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"

# OPTIONAL: Want to learn more about what httptrigger is?
% func help httptrigger
 The HTTP trigger lets you invoke a function with an HTTP request. You can use an HTTP trigger to build serverless APIs and respond to webhooks. 

Programming model v4 for Node is currently in preview. The goal of this model is to introduce a more intuitive and idiomatic way of authoring Function triggers and bindings for JavaScript and TypeScript developers. Learn more http://aka.ms/AzFuncNodeV4. %                                                                       

```
