# Exercise: Process change feed events using the Azure Cosmos DB for NoSQL SDK

See [Exercise: Process change feed events using the Azure Cosmos DB for NoSQL SDK](https://learn.microsoft.com/en-us/training/modules/consume-azure-cosmos-db-sql-api-change-feed-use-sdk/6-exercise-process-change-feed-events-use-sdk) for more information.

IMPORTANT: If the lab environment is unavailable, please see the [guide](https://github.com/microsoftlearning/dp-420-cosmos-db-dev/blob/main/instructions/13-change-feed.md) at [https://github.com/microsoftlearning/dp-420-cosmos-db-dev/blob/main/instructions/13-change-feed.md](https://github.com/microsoftlearning/dp-420-cosmos-db-dev/blob/main/instructions/13-change-feed.md)

## Prepare your development environment

```sh
# Clone the repository from the lab
% git clone https://github.com/microsoftlearning/dp-420-cosmos-db-dev

# Navigate to the newly-cloned folder and remove .git
% cd dp-420-cosmos-db-dev

# Remove .git history so we can fold this into our current project for reference
% rm -rf .git

# Navigate to the change feed lab example
% cd 13-change-feed
```

## Create resources in Azure using the CLI

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
