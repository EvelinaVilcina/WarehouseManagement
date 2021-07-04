namespace WarehouseManagement.Models
{
    public class Product
    { 
        public string Name { get; set; }
        public double Price { get; set; }
        public short ColourCode { get; set; }
        public string EanCode { get; set; }
        public int Stock { get; set; }
        public bool IsOutOfStock { get; set; }
    }
}
