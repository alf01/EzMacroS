using System.Collections.Generic;
using EzMacroS.Conditions;

namespace EzMacroS.Commands
{
    public class IfCommand: ICommandWithSubCommands
    {
        public List<ICommand> ConditionCommands { get; }

        public BaseCondition BaseCondition { get; }

        public IfCommand(BaseCondition baseCondition, List<ICommand> conditionCommands)
        {
            BaseCondition = baseCondition;
            ConditionCommands = conditionCommands;
        }
        public void Execute()
        {
            if (BaseCondition.CalculateCondition())
            {
                foreach (var command in ConditionCommands)
                {
                    command.Execute();
                }
            }
        }
    }
}