using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class ShowCaseController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index(string p)
		{
			
			ViewBag.name = p;
			return View();
		}

		[AllowAnonymous]
		public IActionResult CategoryDetails(int id)
		{
			ViewBag.ID = id;
			return View();
		}

      

    }
}
