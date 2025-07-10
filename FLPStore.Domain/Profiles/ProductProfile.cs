using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Domain.Requests.Products;
using FLPStore.Domain.Responses.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLPStore.Domain.Profiles;

public class ProductProfile : AutoMapper.Profile
{
    public ProductProfile()
    {
        //CreateMap<SourceProduct, DestinationProduct>();
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
        CreateMap<Product, PaginatedProductResponse>();
    }
}
