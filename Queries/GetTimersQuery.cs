using MediatR;

namespace ExerciseTimer.API.Queries
{
    public record GetTimersQuery : IRequest<IEnumerable<Models.Timer>>;
}