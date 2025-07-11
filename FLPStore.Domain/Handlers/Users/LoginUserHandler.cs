using AutoMapper;
using FLPStore.Core.DTOs.Response;
using FLPStore.Core.Interfaces;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.Requests.Users;
using FLPStore.Domain.Responses.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Users;

public class LoginUserHandler(ILogger<LoginUserHandler> logger, IUnitOfWork unit, IMapper mapper) : IRequestHandler<LoginUserRequest, IBaseResponse<ILoginUserResponse>>
{
    public async Task<IBaseResponse<ILoginUserResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling LoginUserRequest");
        cancellationToken.ThrowIfCancellationRequested();

        var user = await unit.Users.GetAsync(request.Email, cancellationToken);
        if (user == null || !user.Password.Equals(request.Password))
        {
            logger.LogWarning("User not found with email: {Email}", request.Email);
            return new BaseResponse<ILoginUserResponse>(false, "User not found.");
        }

        logger.LogInformation("User found. Proceeding with login.");

        var response = mapper.Map<LoginUserResponse>(user);
        response.Token = unit.JwtService.GenerateToken(user.Email);

        return new BaseResponse<ILoginUserResponse>(response);
    }
}