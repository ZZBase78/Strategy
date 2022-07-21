using Abstractions.Commands.CommandsInterfaces;

public sealed class HillCommand : IHillCommand
{
    public IHillable Target { get; }

    public HillCommand(IHillable target) => Target = target;
}