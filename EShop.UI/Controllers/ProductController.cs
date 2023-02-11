using Microsoft.AspNetCore.Mvc;

namespace EShop.UI.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
