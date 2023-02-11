using Microsoft.AspNetCore.Mvc;

namespace EShop.UI.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
