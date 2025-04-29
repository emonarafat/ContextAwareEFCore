namespace ContextAwareEFCore;
public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; } = default!;
    public string UserId { get; set; } = default!;
}
