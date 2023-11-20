using System.ComponentModel.DataAnnotations;

namespace Company.DomainModels
{
    public class Category
    {
        [Key]
        [Display(Name = "Category")]
        public long CategoryID { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}