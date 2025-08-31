# Exercise: Set and retrieve a secret from Azure Key Vault by using Azure CLI

See [Create and retrieve secrets from Azure Key Vault](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-secure-solutions/01-key-vault-store-retrieve.html) for more information.

Use the [>_] button to the right of the search bar at the top of the page to create a new cloud shell in the Azure portal, selecting a `Bash` environment. The cloud shell provides a command line interface in a pane at the bottom of the Azure portal. If you are prompted to select a storage account to persist your files, select `No storage account required`, your `subscription`, and then select `Apply`.

In the cloud shell toolbar, in the Settings menu, select Go to Classic version (this is required to use the code editor).

```sh
# Variables
resourceGroup=az204-vault-rg
location=westus
keyVaultName=mykeyvaultname$RANDOM

# Create a resource group
az group create --name $resourceGroup --location $location

# Let's see the key vault name - we'll need it later in the exercise
echo $keyVaultName

# Create a key vault (this may take a few minutes to run)
az keyvault create --name $keyVaultName --resource-group $resourceGroup --location $location

# Assign a role to your Microsoft Entra user name
# To create and retrieve a secret, assign your Microsoft Entra user to the Key Vault Secrets Officer role. This gives your user account permission to set, delete, and list secrets. In a typical scenario you may want to separate the create/read actions by assigning the Key Vault Secrets Officer to one group, and Key Vault Secrets User (can get and list secrets) to another.

# Retrieve the userPrincipalName from your account
userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me \
    --headers 'Content-Type=application/json' \
    --query userPrincipalName --output tsv)

# OPTIONAL: View the userPrincipal you just created
echo $userPrincipal

# Retrieve the resource ID of the key vault
resourceID=$(az keyvault show --resource-group $resourceGroup \
    --name $keyVaultName --query id --output tsv)

# OPTIONAL: View the resource ID of the key vault
echo $resourceID

# Create and assign the Key Vault Secrets Officer role
az role assignment create --assignee $userPrincipal \
    --role "Key Vault Secrets Officer" \
    --scope $resourceID

# Create a secret (example - a password that could be used by an app)
az keyvault secret set --vault-name $keyVaultName \
    --name "MySecret" --value "My secret value"

# Retrieve the secret
az keyvault secret show --name "MySecret" --vault-name $keyVaultName

# Clean up resources
az group delete --name $resourceGroup --no-wait
```
