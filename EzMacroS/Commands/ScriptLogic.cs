using System.Collections.Generic;

namespace EzMacroS.Commands
{
    public class ScriptLogic
    {
        public int BindInt { get; private set; }

        public List<ICommand> CommandsList{ get; private set; }

        public ScriptLogic(int bindKey, List<ICommand> commandsList)
        {
            BindInt = bindKey;
            CommandsList = commandsList;
        }
    }
}