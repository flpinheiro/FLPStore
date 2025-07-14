using FLPStore.Core.Interfaces.Services;
using FLPStore.CrossCutting.DTOs.Requests.Users;
using Moq;

namespace FLPStore.Tests.Mocks.Services;

internal class IdentityServiceMock
{
    public IIdentityService Object => Mock.Object;
    private readonly Mock<IIdentityService> Mock;

    public IdentityServiceMock()
    {
        Mock = new Mock<IIdentityService>(MockBehavior.Strict);
    }
    public IdentityServiceMock SetupCreateUserAsync()
    {
        Mock.Setup(x => x.CreateUserAsync(It.IsAny<ICreateUserRequest>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        return this;
    }
    public IdentityServiceMock SetupCreateUserAsync<TEXception>()
        where TEXception : Exception, new()
    {
        Mock.Setup(x => x.CreateUserAsync(It.IsAny<ICreateUserRequest>(), It.IsAny<CancellationToken>()))
            .Throws<TEXception>();
        return this;
    }
    public IdentityServiceMock VerifyCreateUserAsync(Times times)
    {
        Mock.Verify(x => x.CreateUserAsync(It.IsAny<ICreateUserRequest>(), It.IsAny<CancellationToken>()), times);
        return this;
    }
    public IdentityServiceMock SetupGenerateToken(string token)
    {
        Mock.Setup(x => x.GenerateToken(It.IsAny<ITokenUserRequest>()))
            .Returns(token)
            .Verifiable();
        return this;
    }
    public IdentityServiceMock SetupGenerateToken<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.GenerateToken(It.IsAny<ITokenUserRequest>()))
            .Throws<TException>();
        return this;
    }
    public IdentityServiceMock VerifyGenerateToken(Times times)
    {
        Mock.Verify(x => x.GenerateToken(It.IsAny<ITokenUserRequest>()), times);
        return this;
    }
}
