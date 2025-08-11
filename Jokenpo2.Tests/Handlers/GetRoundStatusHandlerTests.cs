//using Xunit;
//using Moq;
//using Jokenpo2.Application.Handlers;
//using Jokenpo2.Application.Queries;
//using Jokenpo2.Application.Services;
//using Jokenpo2.Domain.DTO;
//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//public class GetRoundStatusHandlerTests
//{
//    [Fact]
//    public async Task Handle_ReturnsCorrectRoundStatus()
//    {
//        var mockService = new Mock<JokenpoService>();

//        var players = new Dictionary<Guid, string>
//        {
//            [Guid.Parse("11111111-1111-1111-1111-111111111111")] = "Carlos",
//            [Guid.Parse("22222222-2222-2222-2222-222222222222")] = "João"
//        };

//        var moves = new Dictionary<Guid, object>
//        {
//            [Guid.Parse("11111111-1111-1111-1111-111111111111")] = new object()
//        };

//        mockService.Setup(s => s.Players).Returns(players);
//        mockService.Setup(s => s.Moves).Returns(moves);

//        var handler = new GetRoundStatusHandler(mockService.Object);

//        var result = await handler.Handle(new GetRoundStatusQuery(), CancellationToken.None);

//        Assert.NotNull(result);
//        Assert.Equal(2, result.Players.Count);
//        Assert.Single(result.Played);
//        Assert.Single(result.NotPlayed);

//        Assert.Contains(result.Played, p => p.Name == "Carlos");
//        Assert.Contains(result.NotPlayed, p => p.Name == "João");
//    }
//}
