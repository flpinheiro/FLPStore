using FLPStore.Core.DTOs.Requests;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.Responses.Products;
using MediatR;

namespace FLPStore.Domain.Requests.Products;

public record GetPaginatedProductRequest: PaginateRequest, IRequest<IPaginatedBaseResponse<IEnumerable<PaginatedProductResponse>>>;
