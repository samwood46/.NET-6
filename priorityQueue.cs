
class OrderPriority
{
    public OrderPriority(int priority) => PriorityBySalesArea = priority; // LEVEL OF PRIORITY
    public int PriorityBySalesArea { get; set; }
}

class OrderPriorityComparer : IComparer<OrderPriority> //What is used to compare
{
    public int Compare(OrderPriority lineOrder1, OrderPriority lineOrder2)
    {
        return lineOrder1.PriorityBySalesArea.CompareTo(lineOrder2.PriorityBySalesArea);

    }


}

class LineOrder
{
    public Guid OrderId;
    public string OrderTitle;
    public string Description;
    public DateTime OrderDate = DateTime.UtcNow;
    public int TotalPrice;
    public List<OrderItem> orderitems { get; private set; }
    public LineOrder(string title, string description = "", List<OrderItem> orderitems = null)
    {
        OrderId = Guid.NewGuid();
        OrderTitle = title;
        Description = description;

        if (orderitems?.Count > 0)
        {
            this.orderitems = orderitems;
            TotalPrice = orderitems!.Sum(s => s.GetTotalPrice());
        }
        else
            this.orderitems = Enumerable.Empty<OrderItem > ().ToList();
    }
    public void AddItem(OrderItem item) => orderitems.Add(item);
    public bool Removeltem(OrderItem item) => orderitems.Remove(item);

}
class OrderItem
{
    public Guid Itemid;
    public string Name;
    public int Quantity = 1;
    public int UnitPrice;
    public OrderItem() => Itemid = Guid.NewGuid();
    public int GetTotalPrice() => UnitPrice * Quantity;
}


public class Solution
{
    public static void Main()
    {
        var lineOrdersQueue = new PriorityQueue<LineOrder, OrderPriority>(new OrderPriorityComparer());
        var lineOrderPriorityVIP = new OrderPriority(15);
        lineOrdersQueue.Enqueue(new LineOrder ("LineOrder #1"), new OrderPriority(30));
        lineOrdersQueue.Enqueue(new LineOrder("LineOrder #2"), new OrderPriority(40)); 
        lineOrdersQueue.Enqueue(new LineOrder("LineOrder #3"), new OrderPriority(20));
        lineOrdersQueue.EnqueueDequeue(new LineOrder("VIP Order #1"), lineOrderPriorityVIP); // adds in one element and then removes the element with the lowest number or highest priority, in this case itself 



        lineOrderPriorityVIP.PriorityBySalesArea = 5; //priority gets set to 5 
        lineOrdersQueue.Enqueue(new LineOrder("VIP Order #2"), new OrderPriority(10)); //second in line
        int total = lineOrdersQueue.Count;
        for (int i = 0; i < total; i++)
        {
           // Console.WriteLine($"Total: {lineOrdersQueue.Count}");

            Console.WriteLine(lineOrdersQueue.Dequeue().OrderTitle);
        }
        Console.WriteLine($"Total: {lineOrdersQueue.Count}");

    }
    
}
