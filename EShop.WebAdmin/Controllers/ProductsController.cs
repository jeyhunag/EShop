using EShop.BLL.Services.Inerfaces;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.WebAdmin.Controllers
{
    [Authorize(Roles = "Operator")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly IHostingEnvironment _hostingEnvironment;


        public ProductsController(IProductService service, IHostingEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ProductDto model = new ProductDto();
            model.CategoryDtos = await _service.GetCategoriesAsync();
            return View(model);
        }

      
        /// <summary>
        ///  Add Product to database with Product Document
        /// </summary>
        /// <param name="itemDto"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto itemDto, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string folderPath = @"Documents\ProductImages";
                string fullPath = Path.Combine(wwwRootPath, folderPath);
                itemDto.ProductDocuments = new List<ProductDocumentDto>();
                foreach (var file in files)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    string realPath = Path.Combine(fullPath, fileName + extension);

                    using (var fileStream = new FileStream(realPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    ProductDocumentDto productDocument = new ProductDocumentDto()
                    {
                        DocumentUrl = @"Documents/ProductImages/" + fileName + extension,
                        

                    };
                    itemDto.ProductDocuments.Add(productDocument);

                }
                if (itemDto.ProductDocuments.Count > 0)
                {
                    itemDto.ProfileDocPath = itemDto.ProductDocuments[0].DocumentUrl;
                }
                await _service.AddAsync(itemDto);

                TempData["success"] = "Product added succecfully";
                return RedirectToAction("Index");
            }


            return View(itemDto);
        }

    }
}
