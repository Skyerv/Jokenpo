using Xunit;
using Moq;
using Jokenpo2.Application.Handlers;
using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

public class RemovePlayerHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsTrue_WhenPlayerRemoved()
    {
        var mockService = new Mock<JokenpoService>();
        var playerId = Guid.NewGuid();

        mockService.Setup(s => s.RemovePlayer(playerId)).Returns(true);

        var handler = new RemovePlayerHandler(mockService.Object);

        var result = await handler.Handle(new RemovePlayerCommand { PlayerId = playerId }, CancellationToken.None);

        Assert.True(result);
    }

    [Fact]
    public async Task Handle_ReturnsFalse_WhenPlayerNotRemoved()
    {
        var mockService = new Mock<JokenpoService>();
        var playerId = Guid.NewGuid();

        mockService.Setup(s => s.RemovePlayer(playerId)).Returns(false);

        var handler = new RemovePlayerHandler(mockService.Object);

        var result = await handler.Handle(new RemovePlayerCommand { PlayerId = playerId }, CancellationToken.None);

        Assert.False(result);
    }
}
