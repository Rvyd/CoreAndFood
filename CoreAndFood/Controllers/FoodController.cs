using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using X.PagedList.Extensions;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context context = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page=1)
        {
            //sayfalama için iki paratme var; kaçıncı sayfadan, sayfada kaç adet  değer olacak
            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }

        [HttpGet] //attribute sayfa gelince çalışır
        public IActionResult FoodAdd()
        {
            //category kısmından x öğesiyle alanları alıp dropdown listenin değerilerine verdim
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),

                                           }).ToList();
            // Controller tarafında oluşturduğum nesneyi view tarafına taşıyorum
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FoodAdd(FoodAdd food)
        {
            Food f = new Food();
            if(food.ImageURL != null) 
            {
                var extension = Path.GetExtension(food.ImageURL.FileName);
                var newimagename=Guid.NewGuid()+extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                food.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }
            f.Name = food.Name;
            f.Price = food.Price;
            f.Stock= food.Stock;
            f.CategoryID = food.CategoryID;
            f.Description = food.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult FoodRemove(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }


        public IActionResult FoodGet(int id)
        {
			var f = foodRepository.TGet(id);
			List<SelectListItem> values = (from x in context.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString(),

										   }).ToList();
            ViewBag.v1 = values;
			
            Food food = new Food()
            {
                FoodID = f.FoodID,
                CategoryID = f.CategoryID,
                Name = f.Name,
                Price = f.Price,
                Stock = f.Stock,
                Description = f.Description,
                ImageURL = f.ImageURL,
            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food food)
        {
            var f = foodRepository.TGet(food.FoodID);
            f.CategoryID= food.CategoryID;
            f.Name = food.Name;
            f.Price = food.Price;
            f.Stock = food.Stock;
            f.Description = food.Description;
            f.ImageURL = food.ImageURL;
            foodRepository.TUpdate(f);
            return RedirectToAction("Index");
        }
    }
}
