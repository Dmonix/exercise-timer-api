using ExerciseTimer.API.Queries;
using ExerciseTimer.API.Services;
using MediatR;

namespace ExerciseTimer.API.Handlers
{
    public class GetTimerHandler : IRequestHandler<GetTimerQuery, Models.Timer>
    {
        private readonly TimersService _timersService;

        public GetTimerHandler(TimersService timersService)
        {
            _timersService = timersService;
        }

        public async Task<Models.Timer> Handle(GetTimerQuery request, CancellationToken cancellationToken)
        {
            var timer = await _timersService.GetTimerAsync(request.timerId);
            return timer;
        }
    }
}