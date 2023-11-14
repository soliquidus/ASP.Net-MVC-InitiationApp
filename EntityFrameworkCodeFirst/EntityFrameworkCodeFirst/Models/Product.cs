using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public long ProductID { get; set; }
        
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        
        [Display(Name = "Price")]
        public decimal? Price { get; set; }
        
        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date of Purchase")]
        public DateTime? Dop { get; set; }
        
        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }
        
        [Display(Name = "Category Id")]
        public long? CategoryID { get; set; }
        
        [Display(Name = "Brand Id")]
        public long? BrandID { get; set; }
        
        [Display(Name = "Active")]
        public bool? Active { get; set; }
        
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Quantity")]
        public decimal? Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}