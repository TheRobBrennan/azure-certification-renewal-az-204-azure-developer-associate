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

// Create a new delegate variable to handle the processing of the change feed
ChangesHandler<Product> handleChanges = async (
    IReadOnlyCollection<Product> changes,
    CancellationToken cancellationToken
) => {
  // Print a message to the console to indicate that we are handling a batch of changes
  Console.WriteLine($"START\tHandling batch of changes...");

  // Iterate over each product in the changes collection
  foreach(Product product in changes)
  {
    // Use the built-in asynchronous Console.WriteLineAsync static method to print the id and name properties of the product variable
    await Console.Out.WriteLineAsync($"Detected Operation:\t[{product.id}]\t{product.name}");
  }

};

// Create a new ChangeFeedProcessorBuilder instance using the sourceContainer and handleChanges delegate
var builder = sourceContainer.GetChangeFeedProcessorBuilder<Product>(
    processorName: "productsProcessor",
    onChangesDelegate: handleChanges
);

// Create a new ChangeFeedProcessor instance using the builder and leaseContainer
ChangeFeedProcessor processor = builder
    .WithInstanceName("consoleApp")
    .WithLeaseContainer(leaseContainer)
    .Build();

// Start the processor asynchronously
await processor.StartAsync();
Console.WriteLine($"RUN\tListening for changes...");
Console.WriteLine("Press any key to stop");
Console.ReadKey();  // Wait for a key press to stop the processor
await processor.StopAsync();
