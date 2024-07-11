using System.Collections.Generic;

namespace EzMacroS.Commands
{
    public interface ICommandWithSubCommands: ICommand
    {
        List<ICommand> ConditionCommands { get; }
    }
}