
using System.Collections.Concurrent;
using System.Collections.Immutable;
public class OrderItem
{

    public int id;
    public string Name;
    public string? Description;
    public int Quantity = 1;
    public int UnitPrice;

    public async Task<int> GetTotalPrice() => UnitPrice * Quantity;

}

public class Program
{
    public static async Task Main(string[] args)
    {
        // Initialize a counter for processed items

        int count = 0;

        // Concurrent dictionary to store order IDs and their total prices
        ConcurrentDictionary<int, int> orderBasket = new();

        // Create an immutable list of order items with sample data
        ImmutableList<OrderItem> orderItems = Enumerable.Range(0, 5).Select(index => new OrderItem()
        {
            id = index + 1,
            Name = $"Item {index + 1}",
            UnitPrice = (index + 1) * 10
        }).ToImmutableList(); // going to be a list of id = 1 pprice = 10 , id 2 price = 20

        // Create a cancellation token source that cancels after 5000 milliseconds (5 seconds)

        var tokenSource = new CancellationTokenSource();
        tokenSource.CancelAfter(5000);
        var options = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 5, // Limit maximum parallel threads to 5
            CancellationToken = tokenSource.Token // Use the cancellation token for parallel tasks

        };

        // Perform parallel processing asynchronously on orderItems

        var loopTask = Parallel.ForEachAsync(orderItems, options, async (item, token) =>
        {
            int totalUnitPrice = await item.GetTotalPrice();
            orderBasket.TryAdd(item.id, totalUnitPrice);
            count++;
            await Task.Delay(2000, token);

        });
        // Output the total count of processed items

        Console.WriteLine(count); // the count hasn't been incremented yet as the loop task hasn't been called. there fore the count is 0
        Console.WriteLine(orderBasket.Sum(s => s.Value)); // the sum is 150
        await loopTask; 
    }
}
