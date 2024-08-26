# Exercise: Set and retrieve a secret from Azure Key Vault by using Azure CLI

See [Exercise: Set and retrieve a secret from Azure Key Vault by using Azure CLI](https://learn.microsoft.com/en-us/training/modules/implement-azure-key-vault/5-set-retrieve-secret-azure-key-vault) for more information.

```sh
# Variables
myKeyVault=az204vault-$RANDOM
myLocation=westus

# Create a resource group
az group create --name az204-vault-rg --location $myLocation

# Create a key vault (this may take a few minutes to run)
az keyvault create --name $myKeyVault --resource-group az204-vault-rg --location $myLocation

# Once the keyvault has been created, if you're running this from your local machine and not the Azure CLI in the browser, 
# you may find you need to explicitly navigate to the `Key Vault` and under `Access control (IAM)` explicitly add an account as a `Key Vault Administrator`.

# Create a secret (example - a password that could be used by an app)
az keyvault secret set --vault-name $myKeyVault --name "ExamplePassword" --value "hVFkk965BuUv"

# Retrieve the secret
az keyvault secret show --name "ExamplePassword" --vault-name $myKeyVault

# Clean up resources
az group delete --name az204-vault-rg --no-wait
```
