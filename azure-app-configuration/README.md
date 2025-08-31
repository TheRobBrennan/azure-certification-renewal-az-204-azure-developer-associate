# Exercise: Create an Azure App Configuration resource and add configuration information

See [Create an Azure App Configuration resource and add configuration information](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-secure-solutions/02-app-config-retrieve.html) for more information.

Use the [>_] button to the right of the search bar at the top of the page to create a new cloud shell in the Azure portal, selecting a `Bash` environment. The cloud shell provides a command line interface in a pane at the bottom of the Azure portal. If you are prompted to select a storage account to persist your files, select `No storage account required`, your `subscription`, and then select `Apply`.

In the cloud shell toolbar, in the Settings menu, select Go to Classic version (this is required to use the code editor).

```sh
resourceGroup=myResourceGroup
location=westus
appConfigName=appconfigname$RANDOM
# Example appConfigName -> appconfigname16144

# Create a resource group
az group create --name $resourceGroup --location $location

# Run the following command to ensure the Microsoft.AppConfiguration provider is registered for your subscription
az provider register --namespace Microsoft.AppConfiguration

# It can take a few minutes for the registration to complete. Run the following command to check the status of the registration. Proceed to the next step when the results return Registered.
az provider show --namespace Microsoft.AppConfiguration --query "registrationState"

# Create an Azure App Configuration resource. This can take a few minutes to run.
az appconfig create --location $location \
    --name $appConfigName \
    --resource-group $resourceGroup
    --sku Free

# Assign a role to your Microsoft Entra user name
# Retrieve the userPrincipalName from your account
userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me \
    --headers 'Content-Type=application/json' \
    --query userPrincipalName --output tsv)
# Retrieve the resource ID of your App Configuration service
resourceID=$(az appconfig show --resource-group $resourceGroup \
    --name $appConfigName --query id --output tsv)

# Create and assign the App Configuration Data Reader role
az role assignment create --assignee $userPrincipal \
    --role "App Configuration Data Reader" \
    --scope $resourceID

# Add configuration information with Azure CLI
az appconfig kv set --name $appConfigName \
    --key Dev:conStr \
    --value connectionString \
    --yes

# Create a .NET console app to retrieve configuration information
mkdir appconfig
cd appconfig

dotnet new console

dotnet add package Azure.Identity
dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration

# Add the code for the project
code Program.cs

# Clean, build, and run the app
dotnet clean
dotnet build
dotnet run

# Clean up resources
az group delete --name $resourceGroup --no-wait
```
