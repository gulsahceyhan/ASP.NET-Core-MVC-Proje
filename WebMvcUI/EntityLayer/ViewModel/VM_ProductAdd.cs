namespace WebMvcUI.ViewModel;

public class VM_ProductAdd
{
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public Int16 UnitsInStock { get; set; }
    public Int16 UnitsOnOrder { get; set; }
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
}