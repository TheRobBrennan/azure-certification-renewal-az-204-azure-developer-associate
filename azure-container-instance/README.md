# Exercise - Deploy a container instance by using the Azure CLI

Please see [Exercise - Deploy a container instance by using the Azure CLI](https://learn.microsoft.com/en-us/training/modules/create-run-container-images-azure-container-instances/3-run-azure-container-instances-cloud-shell) for more information.

In this exercise you learn how to perform the following actions:

- Create a resource group for the container
- Create a container
- Verify the container is running

```sh
# Variables
myRG=az204-aci-rg
myLocation=westus

# Create a unique DNS name to expose your container to the Internet
DNS_NAME_LABEL=aci-example-$RANDOM

# Create a resource group
az group create --name $myRG --location $myLocation

# Create a container (this may take a few minutes to complete)
az container create --resource-group $myRG \
    --name mycontainer \
    --image mcr.microsoft.com/azuredocs/aci-helloworld \
    --ports 80 \
    --dns-name-label $DNS_NAME_LABEL --location $myLocation

# Verify the container is running
az container show --resource-group $myRG \
    --name mycontainer \
    --query "{FQDN:ipAddress.fqdn,ProvisioningState:provisioningState}" \
    --out table

# EXAMPLE OUTPUT:
# FQDN                                        ProvisioningState
# ------------------------------------------  -------------------
# aci-example-31658.westus.azurecontainer.io  Succeeded

# VERIFY: Open your browser and view http://aci-example-31658.westus.azurecontainer.io/

## Clean up resources

az group delete --name $myRG --no-wait
```
