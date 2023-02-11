using Microsoft.AspNetCore.Mvc;

namespace EShop.UI.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
