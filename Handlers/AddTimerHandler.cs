using ExerciseTimer.API.Commands;
using ExerciseTimer.API.Services;
using MediatR;

namespace ExerciseTimer.API.Handlers
{
    public class AddTimerHandler : IRequestHandler<AddTimerCommand>
    {
        private readonly TimersService _timersService;

        public AddTimerHandler(TimersService timersService)
        {
            _timersService = timersService;
        }

        public async Task Handle(AddTimerCommand request, CancellationToken cancellationToken)
        {
            await _timersService.CreateTimerAsync(request.Timer);
            return;
        }
    }
}