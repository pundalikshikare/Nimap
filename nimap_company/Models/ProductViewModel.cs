using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nimap_company.Models
{
    public class ProductViewModel
    {
        public int ProductId { set; get; }
        [Display(Name = "Product Name")]
        public string ProductName { set; get; }
        public int CategoryId { set; get; }
        [Display(Name = "Category Name")]
        public string CategoryName { set; get; }

    }
    public class ProductPaginationViewModel
    {
        public List<ProductViewModel> Products { get; set; }  
        public int CurrentPage { get; set; }         
        public int TotalPages { get; set; }         
        public int PageSize { get; set; }          
    }
}