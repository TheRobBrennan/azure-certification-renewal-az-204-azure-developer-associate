# Exercise: Create resources by using the Microsoft .NET SDK v3

See [Exercise: Create resources by using the Microsoft .NET SDK v3](https://learn.microsoft.com/en-us/training/modules/work-with-cosmos-db/3-exercise-work-cosmos-db-dotnet) for more information.

In this exercise, you create a console app to perform the following operations in Azure Cosmos DB:

- Connect to an Azure Cosmos DB account
- Create a database
- Create a container

## Create resources in Azure

```sh
# Variables
myRG=az204-cosmos-rg
myLocation=westus

# This is a unique name to identify your Azure Cosmos DB account. 
# The name can only contain lowercase letters, numbers, and 
# the hyphen (-) character - and be between 3-31 characters in length
myCosmosDBacct=rbaz204

# Create a resource group
az group create --location $myLocation --name $myRG

# Create the Azure Cosmos DB account
az cosmosdb create --name $myCosmosDBacct --resource-group $myRG

```

Once your Azure Cosmos DB account has been created, please be sure to take note of the `documentEndpoint` shown in the JSON response for later use in this exercise.

In my example, `documentEndpoint` is:

```json
{
  "documentEndpoint": "https://rbaz204-westus.documents.azure.com:443/"
}
```

## Set up the console application

```sh
# Create a folder for our console application and navigate to it
mkdir az204-cosmos
cd az204-cosmos

# Create the .NET console app
dotnet new console

```

## Build the console app

```sh
# Add the Microsoft.Azure.Cosmos package to the project
dotnet add package Microsoft.Azure.Cosmos

```

## Add code to connect to an Azure Cosmos DB account to create our database and container

Please see [./az204-cosmos/Program.cs](./az204-cosmos/Program.cs) for additional work in our console application.

## Run the application

In a terminal in VS Code, check for any errors and run the application if successful:

```sh
# Navigate to the command line application directory
cd az204-cosmos

# Build the application
dotnet build

# Run the application
dotnet run

```

## Clean up resources

```sh
az group delete --name $myRG --no-wait

```
