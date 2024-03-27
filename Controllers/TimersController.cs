using ExerciseTimer.API.Commands;
using ExerciseTimer.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExerciseTimer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TimersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var timers = await _mediator.Send(new GetTimersQuery());
            return Ok(timers);
        }

        // GET api/<TimersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var timer = await _mediator.Send(new GetTimerQuery(id));
            return Ok(timer);
        }

        // POST api/<TimersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Timer newTimer)
        {
            await _mediator.Send(new AddTimerCommand(newTimer));
            return Ok();
        }

        // PUT api/<TimersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Models.Timer updatedTimer)
        {
            await _mediator.Send(new UpdateTimerCommand(id, updatedTimer));
            return Ok();
        }

        // DELETE api/<TimersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException("How did you hit this?");
        }
    }
}