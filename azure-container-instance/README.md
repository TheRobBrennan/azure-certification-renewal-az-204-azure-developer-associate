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

# Create a resource group
az group create --name $myRG --location $myLocation

```
