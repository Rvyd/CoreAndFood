using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace CoreAndFood.ViewComponents
{
	public class FoodFilterByName :ViewComponent
	{
		public IViewComponentResult Invoke(string p)
		{
			ViewBag.ShowSlider = false;
			FoodRepository foodRepository = new FoodRepository();
			if (!string.IsNullOrEmpty(p)) 
			{
				return View(foodRepository.List(x => x.Name == p));
			}
			return View(foodRepository.TList());
		}
	}
}
