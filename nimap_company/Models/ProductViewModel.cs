using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nimap_company.Models
{
    public class ProductViewModel
    {
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }

    }
    public class ProductPaginationViewModel
    {
        public List<ProductViewModel> Products { get; set; }  // List of products to display
        public int CurrentPage { get; set; }         // Current page number
        public int TotalPages { get; set; }          // Total number of pages
        public int PageSize { get; set; }            // Number of records per page
    }
}