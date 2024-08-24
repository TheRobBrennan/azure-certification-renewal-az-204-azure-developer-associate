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
# Make sure you have activated your virtual environment
% source .venv/bin/activate

# Initialize a Python Azure Functions Project
(.venv) % func init --python
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
(.venv) % func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"
Appending to /Users/rob/repos/azure-certification-renewal-az-204-azure-developer-associate/azure-functions/python/demo-azure-cli/function_app.py
The function "HttpExample" was created successfully from the "HTTP trigger" template.

```

## Run the function locally

```sh
# Make sure you have activated your virtual environment
% source .venv/bin/activate

# TROUBLESHOOTING: Did you install the Azurite extension for VS Code at https://marketplace.visualstudio.com/items?itemName=Azurite.azurite
# Open the VS Code command palette and run `Azurite: Start`

# Run the function locally
(.venv) % func start
Found Python version 3.11.1 (python3).

Azure Functions Core Tools
Core Tools Version:       4.0.5907 Commit hash: N/A +807e89766a92b14fd07b9f0bc2bea1d8777ab209 (64-bit)
Function Runtime Version: 4.834.3.22875

[2024-08-24T05:11:30.392Z] Worker process started and initialized.

Functions:

        HttpExample:  http://localhost:7071/api/HttpExample

For detailed output, run func with --verbose flag.
[2024-08-24T05:11:35.342Z] Host lock lease acquired by instance ID '0000000000000000000000002D9F298A'.

```

Copy the URL of your HTTP function from this output to a browser and append the query string ?name=<YOUR_NAME>, making the full URL like [http://localhost:7071/api/HttpExample?name=Rob](http://localhost:7071/api/HttpExample?name=Rob)

```sh
[2024-08-24T05:16:22.624Z] Executing 'Functions.HttpExample' (Reason='This function was programmatically called via the host APIs.', Id=d70df015-5013-4a0e-ac57-0aa14f910f9f)
[2024-08-24T05:16:22.664Z] Python HTTP trigger function processed a request.
[2024-08-24T05:16:22.712Z] Executed 'Functions.HttpExample' (Succeeded, Id=d70df015-5013-4a0e-ac57-0aa14f910f9f, Duration=118ms)
^C
```

## Create supporting Azure resources for your function

Before you can deploy your function code to Azure, you need to create three resources:

- A resource group, which is a logical container for related resources.
- A Storage account, which is used to maintain state and other information about your functions.
- A function app, which provides the environment for executing your function code. A function app maps to your local function project and lets you group functions as a logical unit for easier management, deployment, and sharing of resources.

```sh
# Make sure you have logged in to Azure
% az login

# Create a resource group
% az group create --name AzureFunctionsQuickstart-rg --location westus

# Create a general-purpose storage account named sademorb in your resource group and region
% az storage account create --name sademorb --location westus --resource-group AzureFunctionsQuickstart-rg --sku Standard_LRS --allow-blob-public-access false

# Create the function app in Azure
# NOTE: Python functions only run on Linux, so we need to specify the --os-type flag
% az functionapp create --resource-group AzureFunctionsQuickstart-rg --consumption-plan-location westus --runtime python --runtime-version 3.11 --functions-version 4 --name sademorb --os-type linux --storage-account sademorb

```

## Deploy the function project to Azure

```sh
# Publish to Azure
% func azure functionapp publish sademorb
Getting site publishing info...
[2024-08-24T05:25:48.652Z] Starting the function app deployment...
Removing WEBSITE_CONTENTAZUREFILECONNECTIONSTRING app setting.
Removing WEBSITE_CONTENTSHARE app setting.
Creating archive for current directory...
Performing remote build for functions project.
Uploading 7.9 MB [################################################################################]
Remote build in progress, please wait...
Updating submodules.
Preparing deployment for commit id '1e037638-7'.
PreDeployment: context.CleanOutputPath False
PreDeployment: context.OutputPath /home/site/wwwroot
Repository path is /tmp/zipdeploy/extracted
Running oryx build...
Command: oryx build /tmp/zipdeploy/extracted -o /home/site/wwwroot --platform python --platform-version 3.11 -p packagedir=.python_packages/lib/site-packages
Operation performed by Microsoft Oryx, https://github.com/Microsoft/Oryx
You can report issues at https://github.com/Microsoft/Oryx/issues

Oryx Version: 0.2.20230210.1, Commit: a49c8f6b8abbe95b4356552c4c884dea7fd0d86e, ReleaseTagName: 20230210.1

Build Operation ID: 1768b4254cdff4f9
Repository Commit : 1e037638-7090-4211-9fb0-b344fe8bc7f3
OS Type           : bullseye
Image Type        : githubactions

Detecting platforms...
Detected following platforms:
  python: 3.11.8
Version '3.11.8' of platform 'python' is not installed. Generating script to install it...


Source directory     : /tmp/zipdeploy/extracted
Destination directory: /home/site/wwwroot


Downloading and extracting 'python' version '3.11.8' to '/tmp/oryx/platforms/python/3.11.8'...
Detected image debian flavor: bullseye.
Downloaded in 2 sec(s).
Verifying checksum...
Extracting contents...
performing sha512 checksum for: python...
Done in 5 sec(s).

image detector file exists, platform is python..
OS detector file exists, OS is bullseye..
Python Version: /tmp/oryx/platforms/python/3.11.8/bin/python3.11
Creating directory for command manifest file if it does not exist
Removing existing manifest file

Running pip install...
Done in 1 sec(s).
[05:26:11+0000] Collecting azure-functions
[05:26:11+0000]   Downloading azure_functions-1.20.0-py3-none-any.whl (181 kB)
[05:26:11+0000] Installing collected packages: azure-functions
[05:26:11+0000] Successfully installed azure-functions-1.20.0
WARNING: Running pip as the 'root' user can result in broken permissions and conflicting behaviour with the system package manager. It is recommended to use a virtual environment instead: https://pip.pypa.io/warnings/venv
WARNING: You are using pip version 21.2.4; however, version 24.2 is available.
You should consider upgrading via the '/tmp/oryx/platforms/python/3.11.8/bin/python3.11 -m pip install --upgrade pip' command.
Not a vso image, so not writing build commands
Preparing output...

Copying files to destination directory '/home/site/wwwroot'...
Done in 0 sec(s).

Removing existing manifest file
Creating a manifest file...
Manifest file created.
Copying .ostype to manifest output directory.

Done in 7 sec(s).
Running post deployment command(s)...

Generating summary of Oryx build
Deployment Log file does not exist in /tmp/oryx-build.log
The logfile at /tmp/oryx-build.log is empty. Unable to fetch the summary of build
Triggering recycle (preview mode disabled).
Linux Consumption plan has a 1.5 GB memory limit on a remote build container.
To check our service limit, please visit https://docs.microsoft.com/en-us/azure/azure-functions/functions-scale#service-limits
Writing the artifacts to a squashfs file
Parallel mksquashfs: Using 1 processor
Creating 4.0 filesystem on /home/site/artifacts/functionappartifact.squashfs, block size 131072.

[=============================================================-] 1633/1633 100%

Exportable Squashfs 4.0 filesystem, gzip compressed, data block size 131072
        compressed data, compressed metadata, compressed fragments,
        compressed xattrs, compressed ids
        duplicates are removed
Filesystem size 7249.51 Kbytes (7.08 Mbytes)
        30.43% of uncompressed filesystem size (23823.83 Kbytes)
Inode table size 17164 bytes (16.76 Kbytes)
        29.34% of uncompressed inode table size (58500 bytes)
Directory table size 17501 bytes (17.09 Kbytes)
        36.76% of uncompressed directory table size (47613 bytes)
Number of duplicate files found 85
Number of inodes 1820
Number of files 1623
Number of fragments 163
Number of symbolic links  0
Number of device nodes 0
Number of fifo nodes 0
Number of socket nodes 0
Number of directories 197
Number of ids (unique uids + gids) 1
Number of uids 1
        root (0)
Number of gids 1
        root (0)
Creating placeholder blob for linux consumption function app...
SCM_RUN_FROM_PACKAGE placeholder blob scm-latest-sademorb.zip located
Uploading built content /home/site/artifacts/functionappartifact.squashfs for linux consumption function app...
Resetting all workers for sademorb.azurewebsites.net
Deployment successful. deployer = Push-Deployer deploymentPath = Functions App ZipDeploy. Extract zip. Remote build.
Remote build succeeded!
[2024-08-24T05:26:29.673Z] Syncing triggers...
Functions in sademorb:
    HttpExample - [httpTrigger]
        Invoke url: https://sademorb.azurewebsites.net/api/httpexample

```

In the above example, we can see that our httpexample function has been deployed to [https://sademorb.azurewebsites.net/api/httpexample](https://sademorb.azurewebsites.net/api/httpexample) 🤓

## Invoke the function on Azure

Open a browser and test your function by adding a `name` query parameter to the URL - [https://sademorb.azurewebsites.net/api/httpexample?name=Rob](https://sademorb.azurewebsites.net/api/httpexample?name=Rob)
