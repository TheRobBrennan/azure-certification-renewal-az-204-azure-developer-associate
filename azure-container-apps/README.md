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

## Create an environment

```sh
# Variables
myRG=az204-appcont-rg
myLocation=westus
myAppContEnv=az204-env-$RANDOM

# Create a resource group for your container app
az group create \
    --name $myRG \
    --location $myLocation

```

With the CLI upgraded and a new resource group available, you can create a Container Apps environment and deploy your container app.

An environment in Azure Container Apps creates a secure boundary around a group of container apps. Container Apps deployed to the same environment are deployed in the same virtual network and write logs to the same Log Analytics workspace.

```sh
# Create an environment
az containerapp env create \
    --name $myAppContEnv \
    --resource-group $myRG \
    --location $myLocation

# Create a container app
az containerapp create \
    --name my-container-app \
    --resource-group $myRG \
    --environment $myAppContEnv \
    --image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest \
    --target-port 80 \
    --ingress 'external' \
    --query properties.configuration.ingress.fqdn
```

By setting `--ingress` to `external`, you make the container app available to public requests. The command returns a link to access your app:

```sh
Container app created. Access your app at https://my-container-app.thankfulglacier-4ec92be9.westus.azurecontainerapps.io/

"my-container-app.thankfulglacier-4ec92be9.westus.azurecontainerapps.io"
```

If you view the link provided, you should see something similar to:

![https://learn.microsoft.com/en-us/training/wwl-azure/implement-azure-container-apps/media/azure-container-apps-exercise.png](https://learn.microsoft.com/en-us/training/wwl-azure/implement-azure-container-apps/media/azure-container-apps-exercise.png)

Last but not least, we want to clean up our resources:

```sh
# Delete the resource group and all of the resources we created
az group delete --name $myRG
```
