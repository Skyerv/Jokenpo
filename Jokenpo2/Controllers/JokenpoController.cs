using Jokenpo2.Application.Commands;
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
    }
}
