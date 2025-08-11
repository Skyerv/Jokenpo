using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Handlers;
using Jokenpo2.Application.Services;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xunit;

public class EndRoundHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsWinnerAndClearsRound_WhenResultIsNotNull()
    {
        var mockService = new Mock<JokenpoService>();
        var winnerId = Guid.NewGuid();
        var winnerName = "Carlos";

        mockService.Setup(s => s.EndRound()).Returns((winnerId, winnerName));
        mockService.Setup(s => s.ClearRound());

        var handler = new EndRoundHandler(mockService.Object);

        var result = await handler.Handle(new EndRoundCommand(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(winnerId, result?.winnerId);
        Assert.Equal(winnerName, result?.winnerName);
        mockService.Verify(s => s.ClearRound(), Times.Once);
    }

    [Fact]
    public async Task Handle_ReturnsNullAndDoesNotClearRound_WhenResultIsNull()
    {
        var mockService = new Mock<JokenpoService>();

        mockService.Setup(s => s.EndRound()).Returns(() => null);

        var handler = new EndRoundHandler(mockService.Object);

        var result = await handler.Handle(new EndRoundCommand(), CancellationToken.None);

        Assert.Null(result);
        mockService.Verify(s => s.ClearRound(), Times.Never);
    }
}
