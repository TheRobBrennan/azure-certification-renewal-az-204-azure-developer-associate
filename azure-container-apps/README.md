# Exercise - Deploy a container app

See [Exercise - Deploy a container app](https://learn.microsoft.com/en-us/training/modules/implement-azure-container-apps/3-exercise-deploy-app) for more details.

## Prepare your environment

Add the Azure Container Apps extension for the CLI and register the Microsoft.App namespace and Microsoft.OperationalInsights namespaces for use.

```sh
# Install the Azure Container Apps extension for the CLI
az extension add --name containerapp --upgrade

# Register the Microsoft.App namespace
# NOTE: Azure Container Apps resources have migrated from the Microsoft.Web namespace to the Microsoft.App namespace.
az provider register --namespace Microsoft.App

# Register the Microsoft.OperationalInsights provider for the Azure Monitor Log Analytics workspace if you haven't used it before
az provider register --namespace Microsoft.OperationalInsights

# NOTE: Registering the Microsoft.App namespace and Microsoft.OperationalInsights can each take a few minutes to complete.
```
