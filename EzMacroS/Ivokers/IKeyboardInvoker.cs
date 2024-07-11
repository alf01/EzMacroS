namespace EzMacroS.Ivokers
{
    public interface IKeyboardInvoker
    {
        void ExecuteKey(bool isDown, byte keyCode);
    }
}