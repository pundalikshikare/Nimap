using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace nimap_company.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }
        [Display(ShortName = "Category Name")]
        public string CategoryName { set; get; }
        // Navigation property for related Products
        public virtual ICollection<Product> Products { get; set; }
    }
}