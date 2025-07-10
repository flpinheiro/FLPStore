using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace FLPStore.Tests.Stubs;

internal static class MapperStub
{
    public static IMapper GetMapper(params Profile[] profiles)
    {
        var loggerFactory = new Mock<ILoggerFactory>();
        loggerFactory.Setup(factory => factory.CreateLogger(It.IsAny<string>()))
                     .Returns(Mock.Of<ILogger>());
        var configuration = new MapperConfiguration(cfg =>
        {
            profiles.ToList().ForEach(profile => cfg.AddProfile(profile));
        }, loggerFactory.Object);
        return configuration.CreateMapper();
    }
}
