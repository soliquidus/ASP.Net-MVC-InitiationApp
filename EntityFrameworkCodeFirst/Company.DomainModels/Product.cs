﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Company.DomainModels.Validations;

namespace Company.DomainModels
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name can't be blank")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Alphabets only")]
        [MaxLength(40, ErrorMessage = "Product name can be maximum 40 characters long")]
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 characters")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0, 1000000, ErrorMessage = "Price should be in between 0  and 1000000")]
        [DivisibleBy10(ErrorMessage = "Price should in multiples 10")]
        public decimal? Price { get; set; }
        
        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date of Purchase")]
        [DisplayFormat(DataFormatString = "M/d/yyyy", ApplyFormatInEditMode = true)]
        public System.DateTime? Dop { get; set; }

        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Please select availability status")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category can't be blank")]
        public long CategoryID { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand can't be blank")]
        public long BrandID { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }
        
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}