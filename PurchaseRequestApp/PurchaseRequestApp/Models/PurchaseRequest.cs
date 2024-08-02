public class PurchaseRequest
{
    public int Id { get; set; }
    public string PurchaseRequestNumber { get; set; }
    public string ItemCode { get; set; }
    public int ItemQuantity { get; set; }
    public decimal ItemCost { get; set; }
    public decimal TotalCost { get; set; }
    public bool IsApproved { get; set; }
    public bool IsDisapproved { get; set; }
}
