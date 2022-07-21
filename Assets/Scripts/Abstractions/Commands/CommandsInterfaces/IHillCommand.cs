namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IHillCommand : ICommand
    {
        public IHillable Target { get; }
    }
}