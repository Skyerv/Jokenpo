using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Handlers;
using Jokenpo2.Application.Services;
using Jokenpo2.Domain.Enums;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class RegisterMoveHandlerTests
{
    [Fact]
    public async Task Handle_CallsRegisterMove()
    {
        var mockService = new Mock<JokenpoService>();

        var handler = new RegisterMoveHandler(mockService.Object);

        var command = new RegisterMoveCommand
        {
            PlayerId = Guid.NewGuid(),
            Move = (Move)0 
        };

        var result = await handler.Handle(command, CancellationToken.None);

        mockService.Verify(s => s.RegisterMove(command.PlayerId, command.Move), Times.Once);
        Assert.Equal(Unit.Value, result);
    }
}
