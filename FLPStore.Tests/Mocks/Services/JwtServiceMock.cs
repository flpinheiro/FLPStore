using FLPStore.Core.Interfaces.Services;
using Moq;

namespace FLPStore.Tests.Mocks.Services;

internal class JwtServiceMock
{
    public IJwtService Object => Mock.Object;
    private readonly Mock<IJwtService> Mock;

    public JwtServiceMock()
    {
        Mock = new Mock<IJwtService>(MockBehavior.Strict);
    }
    public JwtServiceMock SetupGenerateToken(string token)
    {
        Mock.Setup(x => x.GenerateToken(It.IsAny<string>()))
            .Returns(token)
            .Verifiable();
        return this;
    }
    public JwtServiceMock SetupGenerateToken<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.GenerateToken(It.IsAny<string>()))
            .Throws<TException>();
        return this;
    }
    public JwtServiceMock VerifyGenerateToken(Times times)
    {
        Mock.Verify(x => x.GenerateToken(It.IsAny<string>()), times);
        return this;
    }
}
