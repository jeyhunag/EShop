using Microsoft.AspNetCore.Mvc;

namespace EShop.UI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
