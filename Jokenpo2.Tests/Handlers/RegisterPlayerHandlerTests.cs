using Xunit;
using Moq;
using Jokenpo2.Application.Handlers;
using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

public class RegisterPlayerHandlerTests
{
    [Fact]
    public async Task Handle_CallsRegisterPlayer_AndReturnsId()
    {
        var mockService = new Mock<JokenpoService>();

        Guid? capturedId = null;
        string capturedName = null;

        mockService.Setup(s => s.RegisterPlayer(It.IsAny<Guid>(), It.IsAny<string>()))
            .Callback<Guid, string>((id, name) =>
            {
                capturedId = id;
                capturedName = name;
            });

        var handler = new RegisterPlayerHandler(mockService.Object);
        var command = new RegisterPlayerCommand { Name = "Carlos" };

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(capturedId, result);
        Assert.Equal("Carlos", capturedName);
    }
}
