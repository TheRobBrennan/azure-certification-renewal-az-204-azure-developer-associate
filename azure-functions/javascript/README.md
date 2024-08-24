# Quickstart: Create a JavaScript function in Azure using Visual Studio Code

[EXAMPLE: Using the Azure Portal](./demo-azure-portal/README.md)

See [Quickstart: Create a JavaScript function in Azure from the command line](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-node?tabs=macos%2Cazure-cli%2Cbrowser&pivots=nodejs-model-v4)

## Configure your local environment

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

```

## Create a local function project

```sh
# Create a folder for our function project
% mkdir demo-azure-cli

# Navigate to the folder containing our function project
% cd demo-azure-cli

# Initialize an Azure Functions project
% func init --javascript
The new Node.js programming model is generally available. Learn more at https://aka.ms/AzFuncNodeV4
Writing package.json
Writing .funcignore
Writing .gitignore
Writing host.json
Writing local.settings.json
Writing /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/javascript/demo-azure-cli/.vscode/extensions.json
Running 'npm install'...%                                                                                                                                          

# Add HttpExample as a public function using an HTTP Trigger
% func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous" 
Select a number for template:HTTP trigger
Function name: [httpTrigger] Creating a new file /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/javascript/demo-azure-cli/src/functions/HttpExample.js
The function "HttpExample" was created successfully from the "HTTP trigger" template.

# OPTIONAL: Want to learn more about what httptrigger is?
% func help httptrigger
 The HTTP trigger lets you invoke a function with an HTTP request. You can use an HTTP trigger to build serverless APIs and respond to webhooks. 

Programming model v4 for Node is currently in preview. The goal of this model is to introduce a more intuitive and idiomatic way of authoring Function triggers and bindings for JavaScript and TypeScript developers. Learn more http://aka.ms/AzFuncNodeV4. %                                                                       

```

## Run the function locally

```sh
# Make sure you are in the Azure Function project folder
% func start
Azure Functions Core Tools
Core Tools Version:       4.0.5907 Commit hash: N/A +807e89766a92b14fd07b9f0bc2bea1d8777ab209 (64-bit)
Function Runtime Version: 4.834.3.22875

[2024-08-24T03:38:32.368Z] Worker process started and initialized.

Functions:

        HttpExample: [GET,POST] http://localhost:7071/api/HttpExample

For detailed output, run func with --verbose flag.
[2024-08-24T03:38:37.317Z] Host lock lease acquired by instance ID '0000000000000000000000002D9F298A'.

```

Copy the URL of your HTTP function from this output to a browser and append the query string ?name=<YOUR_NAME>, making the full URL like [http://localhost:7071/api/HttpExample?name=Rob](http://localhost:7071/api/HttpExample?name=Rob)

```sh
[2024-08-24T03:39:41.952Z] Http function processed request for url "http://localhost:7071/api/HttpExample?name=Rob"
[2024-08-24T03:39:41.989Z] Executed 'Functions.HttpExample' (Succeeded, Id=71cfb35e-8daf-4118-82fd-4fd9bf2f7031, Duration=138ms)
[2024-08-24T03:39:47.952Z] Executing 'Functions.HttpExample' (Reason='This function was programmatically called via the host APIs.', Id=11f961ef-e3a3-49cf-bd86-a32f80cc6852)
```
