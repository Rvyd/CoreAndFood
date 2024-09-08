using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Index2()
		{
			return View();
		}

		public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname="Lcd",
                stock=75
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;  
                

        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2() 
        {
            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> cs2= new List<Class2>();
            using(var c=new Context())
            {
                cs2=c.Foods.Select(f => new Class2
                {
                    foodname=f.Name,
                    stock=f.Stock,
                }).ToList();
            }

            return cs2;
        }

        public IActionResult Index4()
        {
            return View();
        }


        public IActionResult Statistics()
        {
            Context context = new Context();
            var deger1 = context.Foods.Count();
            ViewBag.d1 = deger1;
            var deger2=context.Categories.Count();
            ViewBag.d2 = deger2;
            var foid = context.Categories.Where(x => x.CategoryName == "Meyveler").Select(y => y.CategoryID).FirstOrDefault();
            var deger3 = context.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = deger3;
            var deger4 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(x => x.CategoryName == "Sebzeler").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;
            var deger5 = context.Foods.Sum(x=>x.Stock);
            ViewBag.d5 = deger5;
            var deger6 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(x => x.CategoryName == "Bakliyat").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;
            var deger7 = context.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.Name).FirstOrDefault();
            ViewBag.d7 = deger7;
            var deger8 = context.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = context.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;
            var deger10 = context.Foods.Where(y => y.CategoryID == context.Categories.Where(x => x.CategoryName == "Meyveler").Select(z => z.CategoryID).FirstOrDefault()).Sum(k => k.Stock);
            ViewBag.d10= deger10;
            var deger11 = context.Foods.Where(y => y.CategoryID == context.Categories.Where(x => x.CategoryName == "Sebzeler").Select(z => z.CategoryID).FirstOrDefault()).Sum(k => k.Stock);
            ViewBag.d11 = deger11;
            var deger12=context.Foods.OrderByDescending(x=>x.Price).Select(y=>y.Name).FirstOrDefault();
            ViewBag.d12= deger12;
            return View();
        }

    }
}
