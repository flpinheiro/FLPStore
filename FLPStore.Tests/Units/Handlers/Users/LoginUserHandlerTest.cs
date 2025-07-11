using AutoMapper;
using FLPStore.Domain.Handlers.Users;
using FLPStore.Domain.Profiles;
using FLPStore.Domain.Requests.Users;
using FLPStore.Domain.Responses.Users;
using FLPStore.Tests.Fixtures.Models.UserAggragates;
using FLPStore.Tests.Mocks;
using FLPStore.Tests.Mocks.Repositories;
using FLPStore.Tests.Mocks.Services;
using FLPStore.Tests.Stubs;
using Microsoft.Extensions.Logging;
using Moq;

namespace FLPStore.Tests.Units.Handlers.Users;

public class LoginUserHandlerTest
{
    private readonly Mock<ILogger<LoginUserHandler>> logger = new();
    private readonly UnitOfWorkMock unit = new();
    private readonly IMapper mapper = MapperStub.GetMapper(new UserProfile());
    private readonly UserRepositoryMock Users = new();
    private readonly JwtServiceMock jwtService = new();

    private readonly LoginUserHandler handler;

    public LoginUserHandlerTest()
    {
        handler = new LoginUserHandler(logger.Object, unit.Object, mapper);
        unit.WithUserRepository(Users.Object);
        unit.WithJwtService(jwtService.Object);
    }

    [Fact]
    public async Task Should_LoginUser_when_Passowrd_IsCorrect()
    {
        var user = new AppUserFixture()
            .Generate();
        var request = new LoginUserRequest
        {
            Email = user.Email,
            Password = user.Password,
        };

        Users.SetupGetLoginAsync(user);

        jwtService.SetupGenerateToken("token");

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        var data = Assert.IsType<LoginUserResponse>(response.Data);
        Assert.Equal(user.Id, data.Id);
        Assert.Equal(user.Email, data.Email);
        Assert.Equal(user.FirstName, data.FirstName);
        Assert.Equal(user.LastName, data.LastName);

        Users.VerifyGetLoginAsync(Times.Once());

        jwtService.VerifyGenerateToken(Times.Once());
    }

    [Fact]
    public async Task Should_LoginUser_when_Passowrd_IsNotCorrect()
    {
        var user = new AppUserFixture()
            .Generate();
        var request = new LoginUserRequest
        {
            Email = user.Email,
            Password = "another password",
        };

        Users.SetupGetLoginAsync(user);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
        Assert.Null(response.Data);
        Assert.Equal("User not found.", response.Messages.First());

        Users.VerifyGetLoginAsync(Times.Once());

        jwtService.VerifyGenerateToken(Times.Never());
    }
}