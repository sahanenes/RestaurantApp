using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.DtoLayer.ProductDto
{
	public class UpdateProductDto
	{
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
    }
}

