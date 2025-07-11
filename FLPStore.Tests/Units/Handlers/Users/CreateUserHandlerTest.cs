using AutoMapper;
using FLPStore.Domain.Handlers.Users;
using FLPStore.Domain.Profiles;
using FLPStore.Domain.Responses.Users;
using FLPStore.Tests.Fixtures.Requests.Users;
using FLPStore.Tests.Mocks;
using FLPStore.Tests.Mocks.Repositories;
using FLPStore.Tests.Stubs;
using Microsoft.Extensions.Logging;
using Moq;

namespace FLPStore.Tests.Units.Handlers.Users;

public class CreateUserHandlerTest
{
    private readonly Mock<ILogger<CreateUserHandler>> logger = new();
    private readonly UnitOfWorkMock unit = new();
    private readonly IMapper mapper = MapperStub.GetMapper(new UserProfile());
    private readonly UserRepositoryMock Users = new();


    private readonly CreateUserHandler handler;

    public CreateUserHandlerTest()
    {
        handler = new CreateUserHandler(logger.Object, unit.Object, mapper);

        unit.WithUserRepository(Users.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateUser_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreateUserRequestFixture().Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Users.SetupAdd();

        // Act
        var response = await handler.Handle(request, CancellationToken.None);
        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        var data = Assert.IsType<UserResponse>(response.Data);
        Assert.NotNull(data);
        Assert.Equal(request.Email, data.Email);
        Assert.Equal(request.FirstName, data.FirstName);
        Assert.Equal(request.LastName, data.LastName);


        unit.VerifyBeginTransactionAsync(Times.Once())
            .VerifyCommitTransactionAsync(Times.Once())
            .VerifySaveChangesAsync(Times.Once())
            .VerifyRollBackTransactionAsync(Times.Never());

        Users.VerifyAdd(Times.Once());
    }

    [Fact]
    public async Task Handle_ShouldReturnException_WhenSomthingHappens()
    {
        // Arrange
        var request = new CreateUserRequestFixture().Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Users.SetupAdd<Exception>();

        // Act
        var response = await handler.Handle(request, CancellationToken.None);
        // Assert
        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
        Assert.Null(response.Data);

        unit.VerifyBeginTransactionAsync(Times.Once())
            .VerifyCommitTransactionAsync(Times.Never())
            .VerifySaveChangesAsync(Times.Never())
            .VerifyRollBackTransactionAsync(Times.Once());

        Users.VerifyAdd(Times.Once());
    }
}
