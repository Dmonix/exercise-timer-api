using MediatR;

namespace ExerciseTimer.API.Commands
{
    public record UpdateTimerCommand(string timerId, Models.Timer Timer) : IRequest;
}