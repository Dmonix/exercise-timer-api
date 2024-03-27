using MediatR;

namespace ExerciseTimer.API.Commands
{
    public record AddTimerCommand(Models.Timer Timer) : IRequest;
}