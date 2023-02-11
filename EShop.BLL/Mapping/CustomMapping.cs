using AutoMapper;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDocument, ProductDocumentDto>().ReverseMap();
        }
    }
}
