using ExerciseTimer.API.Commands;
using ExerciseTimer.API.Services;
using MediatR;

namespace ExerciseTimer.API.Handlers
{
    public class UpdateTimerHandler : IRequestHandler<UpdateTimerCommand>
    {
        private readonly TimersService _timersService;

        public UpdateTimerHandler(TimersService timersService)
        {
            _timersService = timersService;
        }

        public async Task Handle(UpdateTimerCommand request, CancellationToken cancellationToken)
        {
            var timer = await _timersService.GetTimerAsync(request.timerId);
            if (timer == null)
            {
                throw new Exception("Timer not found");
            }

            await _timersService.UpdateTimerAsync(request.timerId, request.Timer);
            return;
        }
    }
}