namespace firstAPI.model
{
    public class Product
    {
        
            public string Flag { get; set; }
            public int? ProductID { get; set; }
            public string SKU { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int? BrandID { get; set; }
            public int? CategoryID { get; set; }
            public int? SizeID { get; set; }
            public int? ColorID { get; set; }
            public int? SupplierID { get; set; }
            public decimal? PurchasePrice { get; set; }
            public decimal? SalePrice { get; set; }
            public int? ReorderLevel { get; set; }
            public bool? IsActive { get; set; }
    }
    
}
