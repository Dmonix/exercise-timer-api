using ExerciseTimer.API.Queries;
using ExerciseTimer.API.Services;
using MediatR;

namespace ExerciseTimer.API.Handlers
{
    public class GetTimersHandler : IRequestHandler<GetTimersQuery, IEnumerable<Models.Timer>>
    {
        private readonly TimersService timersService;

        public GetTimersHandler(TimersService timersService)
        {
            this.timersService = timersService;
        }

        public async Task<IEnumerable<Models.Timer>> Handle(GetTimersQuery request, CancellationToken cancellationToken)
        {
            return await timersService.GetTimersAsync();
        }
    }
}