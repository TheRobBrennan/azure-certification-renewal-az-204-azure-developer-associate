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
myCosmosDBacct=rbaz204a
myCosmosDB=cosmicworks

# Create a resource group
az group create --location $myLocation --name $myRG

# Create the serverless Azure Cosmos DB account (this may take several minutes)
az cosmosdb create \
  --name $myCosmosDBacct \
  --resource-group $myRG \
  --locations regionName=$myLocation \
  --default-consistency-level "Session" \
  --capabilities EnableServerless

# Create the cosmicworks database
az cosmosdb sql database create \
  --account-name $myCosmosDBacct \
  --name $myCosmosDB \
  --resource-group $myRG

# Create the products container with a partition key of /categoryId
az cosmosdb sql container create \
  --account-name $myCosmosDBacct \
  --database-name $myCosmosDB \
  --name products \
  --resource-group $myRG \
  --partition-key-path "/categoryId"

# Create the productslease container with a partition key of /partitionKey:
az cosmosdb sql container create \
  --account-name $myCosmosDBacct \
  --database-name $myCosmosDB \
  --name productslease \
  --resource-group $myRG \
  --partition-key-path "/partitionKey"

```

Once your Azure Cosmos DB account has been created, please be sure to take note of the `documentEndpoint` shown in the JSON response for later use in this exercise.

In my example, `documentEndpoint` is `https://rbaz204a-westus.documents.azure.com:443/` - we will need to navigate to our `Azure Cosmos DB account` to the `Keys` section to find the `Primary Key` we will need in our application.

## Implement the change feed processor in the .NET SDK

```sh
# Navigate to our change feed project folder
cd dp-420-cosmos-db-dev/13-change-feed
```

In VS Code, take a look at [product.cs](./dp-420-cosmos-db-dev/13-change-feed/product.cs) to see what our `Product` properties are. This lab will use the `id` and `name` properties.

Now, let's look at [script.cs](./dp-420-cosmos-db-dev/13-change-feed/script.cs) so we can update our `endpoint` and `key` variables with our `documentEndpoint` and `Primary Key`, respectively.

Please see comments in [script.cs](./dp-420-cosmos-db-dev/13-change-feed/script.cs) to see how we are building out our application.

Once we are ready to build and run our application:

```sh
# Make sure we are in the 13-change-feed folder where our source C# files are 

# Build and run the project
dotnet run

```

You should see output similar to:

```sh
RUN     Listening for changes...
Press any key to stop

```

Leave both Visual Studio Code and the terminal open before proceeding to the next step.

## Seed your Azure Cosmos DB for NoSQL account with sample data

The proposed tool - `cosmicworks` - does not work as expected on my macOS machine. 😔

Let's just manually create products and see if the change feed listener works:

```sh
RUN     Listening for changes...
Press any key to stop
START   Handling batch of changes...
Detected Operation:     [rb1]   A cool product.
```

✅ Success. Finally.

## Clean up resources

```sh
az group delete --name $myRG --no-wait

```
