using MediatR;

namespace ExerciseTimer.API.Queries
{
    public record GetTimerQuery(string timerId): IRequest<Models.Timer>;
}