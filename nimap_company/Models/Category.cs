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
        [Display(Name = "Category Name")]
        public string CategoryName { set; get; }
        // Navigation property for related Products
        public virtual ICollection<Product> Products { get; set; }
    }

    public class CategoryPaginationViewModel
    {
        public List<Category> Category { get; set; }  
        public int CurrentPage { get; set; }         
        public int TotalPages { get; set; }          
        public int PageSize { get; set; }            
    }
}