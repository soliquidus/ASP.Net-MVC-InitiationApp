using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCodeFirst.Validations;

namespace EntityFrameworkCodeFirst.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public long ProductID { get; set; }
        
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name can't be blank")]
        [RegularExpression(@"^[A-Za-z ]*$", ErrorMessage = "Alphabets only")]
        [MaxLength(40, ErrorMessage = "Product name can be maximum 40 characters long")]
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 characters")]
        public string ProductName { get; set; }
        
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Product Price can't be blank")]
        [Range(0, 100000, ErrorMessage = "Price should be in between 0  and 100000")]
        [DivisibleBy10(ErrorMessage = "Price should in multiples 10")]
        public decimal? Price { get; set; }
        
        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date of Purchase")]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? Dop { get; set; }
        
        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Availability can't be blank")]
        public string AvailabilityStatus { get; set; }
        
        [Display(Name = "Category Id")]
        [Required(ErrorMessage = "Category can't be blank")]
        public long CategoryID { get; set; }
        
        [Display(Name = "Brand Id")]
        [Required(ErrorMessage = "Brand can't be blank")]
        public long BrandID { get; set; }
        
        [Display(Name = "Active")]
        public bool Active { get; set; }
        
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Quantity")]
        public decimal? Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}