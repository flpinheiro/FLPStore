using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Domain.DTOs.Requests.Products;
using FLPStore.Domain.DTOs.Responses.Products;

namespace FLPStore.Domain.Profiles;

public class ProductProfile : AutoMapper.Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
        CreateMap<Product, PaginatedProductResponse>();
    }
}
