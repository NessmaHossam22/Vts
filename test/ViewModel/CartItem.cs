public class CartItem
{

    public List<cart>carts = new List<cart>();
    public double DicCount { get; set; } = 0;
    public double TotalPay { get; set; } = 0;
    public double Total { get; set; } = 0;

}
public class cart
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
