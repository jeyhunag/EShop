using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Services.Inerfaces
{
    public interface IProductService :IGenericService<ProductDto, Product>
    { 
        public Task<List<ProductCategoryDto>> GetCategoriesAsync();
    }
}
