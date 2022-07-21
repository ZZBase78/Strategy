using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public sealed class HillCommandCommandCreator : CancellableCommandCreatorBase<IHillCommand, IHillable>
    {
        protected override IHillCommand CreateCommand(IHillable argument) => new HillCommand(argument);
    }
}