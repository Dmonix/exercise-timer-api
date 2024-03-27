using ExerciseTimer.API.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExerciseTimer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseService exerciseService;
        private readonly IMediator _mediator;

        public ExercisesController(ExerciseService exerciseService, IMediator mediator)
        {
            this.exerciseService = exerciseService;
            _mediator = mediator;
        }

        // GET: api/<ExercisesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var exercises = await exerciseService.GetExercisesAsync();
            return Ok(exercises);
        }

        // GET api/<ExercisesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var exercise = await exerciseService.GetExerciseAsync(id);
            return Ok(exercise);
        }

        // POST api/<ExercisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExercisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExercisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
