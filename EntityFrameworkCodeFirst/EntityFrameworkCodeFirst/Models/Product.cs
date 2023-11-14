using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirst.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public System.DateTime? DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public long? CategoryID { get; set; }
        public long? BrandID { get; set; }
        public bool? Active { get; set; }
        public string Photo { get; set; }

        public decimal? Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}