using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.DTOs.Requests;
using FLPStore.Domain.DTOs.Responses.Products;
using MediatR;

namespace FLPStore.Domain.DTOs.Requests.Products;

public record GetPaginatedProductRequest : PaginateRequest, IRequest<IPaginatedBaseResponse<IEnumerable<PaginatedProductResponse>>>;
