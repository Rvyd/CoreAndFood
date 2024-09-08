using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository = new CategoryRepository();
       // [Authorize]
        public IActionResult Index(string p)
        {
            if(!string.IsNullOrEmpty(p))
            {
                return View(repository.List(x=>x.CategoryName==p));
            }
            return View(repository.TList());
        }

        [HttpGet] //attribute
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CategoryAdd(Category cat)
        {
            if (!ModelState.IsValid)
            {
                repository.TAdd(cat);
                return RedirectToAction("Index");


            }
            return View("CategoryAdd");

        }

        public IActionResult CategoryGet(int id)
        {
            var c = repository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription,
                CategoryID = c.CategoryID,
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category ctgry)
        {
            var c = repository.TGet(ctgry.CategoryID);
            c.CategoryName = ctgry.CategoryName;
            c.CategoryDescription = ctgry.CategoryDescription;
            c.Status = true;
            repository.TUpdate(c);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var c = repository.TGet(id);
            c.Status = false;
            repository.TUpdate(c);
            return RedirectToAction("Index");
        }
    }
    
}
