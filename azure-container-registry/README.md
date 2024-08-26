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

# List the repositories in our registry
az acr repository list --name $myContainerRegistry --output table

# List the tags on our sample hello-world repository
az acr repository show-tags --name $myContainerRegistry \
    --repository sample/hello-world --output table

```

## Run the image in the ACR

```sh
# Run the sample container image
az acr run --registry $myContainerRegistry \
    --cmd '$Registry/sample/hello-world:v1' /dev/null

# NOTE: The cmd parameter in this example runs the container in its default configuration, but cmd supports other docker run parameters or even other docker commands.
```

This should produce output similar to the following:

```sh
Queued a run with ID: cf2
Waiting for an agent...
2024/08/26 01:19:19 Alias support enabled for version >= 1.1.0, please see https://aka.ms/acr/tasks/task-aliases for more information.
2024/08/26 01:19:19 Creating Docker network: acb_default_network, driver: 'bridge'
2024/08/26 01:19:19 Successfully set up Docker network: acb_default_network
2024/08/26 01:19:19 Setting up Docker configuration...
2024/08/26 01:19:19 Successfully set up Docker configuration
2024/08/26 01:19:19 Logging in to registry: rbaz204.azurecr.io
2024/08/26 01:19:20 Successfully logged into rbaz204.azurecr.io
2024/08/26 01:19:20 Executing step ID: acb_step_0. Timeout(sec): 600, Working directory: '', Network: 'acb_default_network'
2024/08/26 01:19:20 Launching container with name: acb_step_0
Unable to find image 'rbaz204.azurecr.io/sample/hello-world:v1' locally
v1: Pulling from sample/hello-world
1b930d010525: Pulling fs layer
1b930d010525: Verifying Checksum
1b930d010525: Download complete
1b930d010525: Pull complete
Digest: sha256:92c7f9c92844bbbb5d0a101b22f7c2a7949e40f8ea90c8b3bc396879d95e899a
Status: Downloaded newer image for rbaz204.azurecr.io/sample/hello-world:v1

Hello from Docker!
This message shows that your installation appears to be working correctly.

To generate this message, Docker took the following steps:
 1. The Docker client contacted the Docker daemon.
 2. The Docker daemon pulled the "hello-world" image from the Docker Hub.
    (amd64)
 3. The Docker daemon created a new container from that image which runs the
    executable that produces the output you are currently reading.
 4. The Docker daemon streamed that output to the Docker client, which sent it
    to your terminal.

To try something more ambitious, you can run an Ubuntu container with:
 $ docker run -it ubuntu bash

Share images, automate workflows, and more with a free Docker ID:
 https://hub.docker.com/

For more examples and ideas, visit:
 https://docs.docker.com/get-started/

2024/08/26 01:19:21 Successfully executed container: acb_step_0
2024/08/26 01:19:21 Step ID: acb_step_0 marked as successful (elapsed time in seconds: 0.876807)

Run ID: cf2 was successful after 3s
```

## Clean up resources

```sh
az group delete --name $myRG --no-wait
```
