﻿using Microsoft.AspNetCore.Mvc;

namespace EShop.UI.Controllers
{
	public class WishlistController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
