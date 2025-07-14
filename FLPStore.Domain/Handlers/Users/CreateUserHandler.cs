using AutoMapper;
using FLPStore.Core.Interfaces;
using FLPStore.Core.Models.UserAggragates;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.DTOs.Requests.Users;
using FLPStore.Domain.DTOs.Responses;
using FLPStore.Domain.DTOs.Responses.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Users;

public class CreateUserHandler(ILogger<CreateUserHandler> logger, IUnitOfWork unit, IMapper mapper) :
    IRequestHandler<CreateUserRequest, IBaseResponse<IUserResponse>>
{
    public async Task<IBaseResponse<IUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Handling CreateUserRequest");
        try
        {
            await unit.BeginTransactionAsync(cancellationToken);

            await unit.IdentityService.CreateUserAsync(request, cancellationToken);
            
            var user = mapper.Map<AppUser>(request);
            unit.Users.Add(user);
            await unit.SaveChangesAsync(cancellationToken);
            await unit.CommitTransactionAsync(cancellationToken);
            var response = mapper.Map<UserResponse>(user);

            logger.LogInformation("User created successfully: {Id}", user.Id);
            return new BaseResponse<IUserResponse>(response);
        }
        catch (Exception)
        {
            logger.BeginScope("Create User rollback: {request}", request);
            await unit.RollbackTransactionAsync(cancellationToken);
            logger.LogError("An error occurred while creating the user.");
            return new BaseResponse<IUserResponse>(false, "An error occurred while creating the user.");
        }
    }
}
