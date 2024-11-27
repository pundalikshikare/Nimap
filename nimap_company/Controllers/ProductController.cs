using nimap_company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace nimap_company.Controllers
{
    public class ProductController : Controller
    {
        DataContext objContext;
        public ProductController()
        {
            objContext = new DataContext();
        }
        #region List Product
        public ActionResult Index(int page = 1, int pageSize = 2)
        {

            // Get the total number of products for pagination
            var totalProducts = objContext.Products.Count();

            // Calculate the total number of pages
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            var result = objContext.Products.OrderBy(o => o.ProductId).Skip((page - 1) * pageSize) // Skip records for previous pages
                             .Take(pageSize)
           .Include(p => p.Categories)
           .Select(p => new ProductViewModel()
           {
               ProductId = p.ProductId,
               ProductName = p.ProductName,
               CategoryId = p.Categories.CategoryId,
               CategoryName = p.Categories.CategoryName
           })
           .ToList();
            // Pass pagination data to the view
            var model = new ProductPaginationViewModel
            {
                Products = result,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            return View(model);
        }

        #endregion
        #region Create Product
        public ActionResult CreateProduct()
        {
            List<Category> category =
              objContext.Categories.ToList();
            ViewBag.CategoryList = new SelectList(category, "CategoryId", "CategoryName");
            return View(new Product());
        }
        [HttpPost]
        public ActionResult CreateProduct(Product Product)
        {
            objContext.Products.Add(Product);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region edit Product
        public ActionResult EditProduct(int id)
        {
            Product Product = objContext.Products.Where(
              x => x.ProductId == id).SingleOrDefault();
            List<Category> category =
             objContext.Categories.ToList();
            ViewBag.CategoryList = new SelectList(category, "CategoryId", "CategoryName", Product.CategoryId);
            return View(Product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model)
        {
            Product Product = objContext.Products.Where(
              x => x.ProductId == model.ProductId).SingleOrDefault();
            if (Product != null)
            {
                objContext.Entry(Product).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
        #region Delete Product
        public ActionResult DeleteProduct(int id)
        {
            var result = objContext.Products
                         .Include(p => p.Categories).Where(p=>p.ProductId==id)
          .Select(p => new ProductViewModel()
          {
              ProductId = p.ProductId,
              ProductName = p.ProductName,
              CategoryId = p.Categories.CategoryId,
              CategoryName = p.Categories.CategoryName
          }).FirstOrDefault();

            return View(result);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id, Product model)
        {
            var Product =
              objContext.Products.Where(x => x.ProductId == id).SingleOrDefault();
            if (Product != null)
            {
                objContext.Products.Remove(Product);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion
    }

}
