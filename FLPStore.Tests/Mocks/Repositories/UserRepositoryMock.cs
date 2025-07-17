using FLPStore.Core.Interfaces.Repositories;
using FLPStore.Core.Models.UserAggragates;
using Moq;

namespace FLPStore.Tests.Mocks.Repositories;

internal class UserRepositoryMock
{
    public IUserRepository Object => Mock.Object;
    private readonly Mock<IUserRepository> Mock;

    public UserRepositoryMock()
    {
        Mock = new Mock<IUserRepository>(MockBehavior.Strict);
    }

    public UserRepositoryMock SetupGetAsync(AppUser user)
    {
        Mock.Setup(x => x.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();
        return this;
    }
    public UserRepositoryMock SetupGetAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }
    public UserRepositoryMock VerifyGetAsync(Times times)
    {
        Mock.Verify(x => x.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), times);
        return this;
    }
    public UserRepositoryMock SetupGetLoginAsync(AppUser? user= null)
    {
        Mock.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();
        return this;
    }
    public UserRepositoryMock VerifyGetLoginAsync(Times times)
    {
        Mock.Verify(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), times);
        return this;
    }
    public UserRepositoryMock SetupAdd()
    {
        Mock.Setup(x => x.Add(It.IsAny<AppUser>()))
            .Verifiable();
        return this;
    }
    public UserRepositoryMock SetupAdd<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.Add(It.IsAny<AppUser>()))
            .Throws<TException>();
        return this;
    }

    public UserRepositoryMock VerifyAdd(Times times)
    {
        Mock.Verify(x => x.Add(It.IsAny<AppUser>()), times);
        return this;
    }
    public UserRepositoryMock SetupEdit()
    {
        Mock.Setup(x => x.Edit(It.IsAny<AppUser>()))
            .Verifiable();
        return this;
    }
    public UserRepositoryMock SetupEdit<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.Edit(It.IsAny<AppUser>()))
            .Throws<TException>();
        return this;
    }
    public UserRepositoryMock VerifyEdit(Times times)
    {
        Mock.Verify(x => x.Edit(It.IsAny<AppUser>()), times);
        return this;
    }

}
