# Exercise: Build and run a container image by using Azure Container Registry Tasks

See [Exercise: Build and run a container image by using Azure Container Registry Tasks](https://learn.microsoft.com/en-us/training/modules/publish-container-image-to-azure-container-registry/6-build-run-image-azure-container-registry) for more information.

In this exercise, you use ACR Tasks to perform the following actions:

- Create an Azure Container Registry (ACR)
- Build and push image from a Dockerfile
- Verify the results
- Run the image in the ACR

## Create an Azure Container Registry

```sh
# Variables
myRG=az204-acr-rg
myLocation=westus
myContainerRegistry=rbaz204

# Create a resource group for the registry
az group create --name $myRG --location $myLocation

# Create a basic container registry. The registry name must be unique within Azure, and contain 5-50 alphanumeric characters.
az acr create --resource-group $myRG \
    --name $myContainerRegistry --sku Basic

# NOTE: The command creates a Basic registry, a cost-optimized option for developers learning about Azure Container Registry.

```

## Build and push image from a Dockerfile

For the purposes of this demo, we're going to create a `Dockerfile` in our `./azure-container-registry` for quick reference:

```sh
# Create an example Dockerfile for us to use with our registry
echo FROM mcr.microsoft.com/hello-world > Dockerfile
```

Now that we have a `Dockerfile` to work with, let's build the image and push it to our registry:

```sh
# Build our image using the Dockerfile and our current directory as the context
az acr build --image sample/hello-world:v1 --registry $myContainerRegistry --file Dockerfile .
```
