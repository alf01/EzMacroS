using System.Drawing;

namespace EzMacroS.Ivokers
{
    public static class Invoker
    {
        private static readonly IKeyboardInvoker kbInvoker = new User32KeyBoardInvoker(); //подкидывать другой инвокер тут, например через intercaption
        private static readonly IMouseInvoker mouseInvoker = new User32MouseInvoker(); //подкидывать другой инвокер тут, например через intercaption

        public static void InvokeKeyBoardEvent(bool isDown, byte keyCode)
        {
            kbInvoker.ExecuteKey(isDown, keyCode);
        }

        public static void InvokeMouseClickEvent(bool isDown, MouseKeys keyCode)
        {
            mouseInvoker.ExecuteKey(isDown, keyCode);
        }

        public static void InvokeMouseMoveEvent(Point point, bool isSlide = false)
        {
            mouseInvoker.ExecuteMove(point, isSlide);
        }
    }
}