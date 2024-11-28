using nimap_company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace nimap_company.Controllers
{
    public class CategoryController : Controller
    {
        DataContext objContext;
        public CategoryController()
        {
            objContext = new DataContext();
        }
        #region List Category
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            
            var totalCategories = objContext.Categories.Count();

            
            var totalPages = (int)Math.Ceiling((double)totalCategories / pageSize);

            var result = objContext.Categories.OrderBy(o => o.CategoryId).Skip((page - 1) * pageSize) // Skip records for previous pages
                             .Take(pageSize).ToList();
            
            var model = new CategoryPaginationViewModel
            {
                Category = result,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            return View(model);
        }

        #endregion
        #region Create Category
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category Category)
        {
            objContext.Categories.Add(Category);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region edit Category
        public ActionResult EditCategory(int id)
        {
            Category Category = objContext.Categories.Where(
              x => x.CategoryId == id).SingleOrDefault();
            return View(Category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            Category Category = objContext.Categories.Where(
              x => x.CategoryId == model.CategoryId).SingleOrDefault();
            if (Category != null)
            {
                objContext.Entry(Category).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
        #region Delete Category
        public ActionResult DeleteCategory(int id)
        {
            var result = objContext.Categories.Find(id);

            return View(result);
        }
        [HttpPost]
        public ActionResult DeleteCategory(int id, Category model)
        {
            var Category =
              objContext.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            if (Category != null)
            {
                objContext.Categories.Remove(Category);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion
    }

}