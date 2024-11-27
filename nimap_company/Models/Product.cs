using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace nimap_company.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { set; get; }
        [Display(ShortName ="Product Name")]
        public string ProductName { set; get; }
        [ForeignKey("Categories")]
        [Display(ShortName = "Category Name")]
        public int CategoryId { set; get; }
        // Navigation property
        public virtual Category Categories { get; set; }
    }
}