using System;
using System.Collections.Generic;

namespace KubeSampleApi.Models
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Products = new HashSet<Product>();
            ProductModelProductDescriptions = new HashSet<ProductModelProductDescription>();
        }

        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}
