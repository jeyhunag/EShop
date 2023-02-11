using EShop.BLL.Services.Inerfaces;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.WebAdmin.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly IGenericService<ProductCategoryDto, ProductCategory> _service;

        public ProductCategoriesController(IGenericService<ProductCategoryDto, ProductCategory> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Update(int id) {
            var category = await _service.GetByIdAsync(id);
            return View(category);

        }
     
        [HttpPost]
        public  IActionResult Update(ProductCategoryDto itemDto)
        {
            var category =  _service.Update(itemDto);
            if (category!=null)
            {
                TempData["success"] = "Kateqoriya uğurla dəyişdirildi.";
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.GetByIdAsync(id);

            return View(category);

        }
        [HttpPost]
        public  IActionResult Delete(ProductCategoryDto itemDto)
        {
                _service.Delete(itemDto.Id);
            TempData["success"] = "Kateqoriya uğurla silindi.";
            return RedirectToAction("Index");
          

        }

        public async Task<IActionResult> Create() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryDto itemDto)
        {

            var category = await _service.AddAsync(itemDto);
            if (category != null)
            {
                TempData["success"] = "Kateqoriya uğurla əlavə edildi.";
                return RedirectToAction("Index");
            }
            return Ok(category);
        }
    }
}
