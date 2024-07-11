using EzMacroS.Ivokers;

namespace EzMacroS.Commands
{
    public class KeyCommand : ICommand
    {
        public KeyCommand(bool isDown, byte keyCode)
        {
            IsDown = isDown;
            KeyCode = keyCode;
        }

        public bool IsDown { get; }
        public byte KeyCode { get; }

        public void Execute()
        {
            Invoker.InvokeKeyBoardEvent(IsDown, KeyCode);
        }
    }
}