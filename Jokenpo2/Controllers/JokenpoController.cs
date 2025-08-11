using Jokenpo2.Application.Commands;
using Jokenpo2.Application.Queries;
using Jokenpo2.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jokenpo2.Api.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPlayer([FromBody] RegisterPlayerCommand command)
        {
            var validator = new RegisterPlayerCommandValidator();
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(RegisterPlayer), new { id }, new { Id = id });
        }

        [HttpDelete("{playerId}")]
        public async Task<IActionResult> RemovePlayer(Guid playerId)
        {
            var removed = await _mediator.Send(new RemovePlayerCommand { PlayerId = playerId });

            if (!removed)
                return NotFound($"Player with ID {playerId} not found.");

            return Ok(new { message = $"Player of ID '{playerId}' has been removed successfully." });
        }
    }

    [ApiController]
    [Route("moves")]
    public class MovesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMove([FromBody] RegisterMoveCommand command)
        {
            var validator = new RegisterMoveCommandValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _mediator.Send(command);
            return Ok(new { Message = "Player with ID [" + command.PlayerId + "] chose " + command.Move });
        }
    }

    [ApiController]
    [Route("round")]
    public class RoundController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoundController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetRoundStatus()
        {
            var result = await _mediator.Send(new GetRoundStatusQuery());
            return Ok(result);
        }

        [HttpPost("end")]
        public async Task<IActionResult> EndRound()
        {
            var result = await _mediator.Send(new EndRoundCommand());

            if (result == null)
                return BadRequest("Round can not be finished. All players must play.");

            return Ok(new
            {
                WinnerId = result.Value.winnerId,
                WinnerName = result.Value.winnerName
            });
        }
    }
}
