using Microsoft.Azure.Cosmos;
using static Microsoft.Azure.Cosmos.Container;

// NOTE: These are ephemeral resources and are created for the purpose of this demo. These keys will be revoked after the demo.
string endpoint = "https://rbaz204a-westus.documents.azure.com:443/";
string key = "EnMM1MvjMyTNvzjKAuNN5KvtkAzmgdgBaHwTWfUizXq0V4mSNwJO9mYfpJGxyloMQJqQ4vyFGDP5ACDbXBvpNg==";

// Connect to our serverless Cosmos DB account
CosmosClient client = new CosmosClient(endpoint, key);

// Get our containers from Cosmos DB
Container sourceContainer = client.GetContainer("cosmicworks", "products");
Container leaseContainer = client.GetContainer("cosmicworks", "productslease");