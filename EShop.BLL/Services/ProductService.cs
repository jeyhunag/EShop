using AutoMapper;
using EShop.BLL.Services.Inerfaces;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using EShop.DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Services
{
    public class ProductService : GenericService<ProductDto, Product>,IProductService 
    {
      
        private readonly IGenericRepository<ProductCategory> _categoryRepository;
        public ProductService(IGenericRepository<Product> genericRepository,
            IMapper mapper, ILogger<GenericService<ProductDto, Product>> logger,
            IGenericRepository<ProductCategory> categoryRepository)
            : base(genericRepository, mapper, logger)
        {
            _categoryRepository = categoryRepository;
        }
        /// <summary>
        /// Get product categories with current product
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryDto>> GetCategoriesAsync()
        {
            
            var categories = await _categoryRepository.GetListAsync();

            var categoryDtos = _mapper.Map<List<ProductCategoryDto>>(categories);
            return categoryDtos;
        }
    }
}
