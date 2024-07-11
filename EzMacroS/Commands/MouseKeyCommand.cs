using EzMacroS.Ivokers;

namespace EzMacroS.Commands
{
    public class MouseKeyCommand: ICommand
    {
        
        public bool IsDown { get; private set; }
        public MouseKeys mKey; 
        
        public MouseKeyCommand(bool isDown, MouseKeys key)
        {
            IsDown = isDown;
            mKey = key;
        }

        public void Execute()
        {
            Invoker.InvokeMouseClickEvent(IsDown, mKey);
        }
    }
}