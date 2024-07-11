using System.Drawing;

namespace EzMacroS.Ivokers
{
    public interface IMouseInvoker
    {
        void ExecuteKey(bool isDown, MouseKeys keyCode);
        void ExecuteMove(Point point, bool isSlide = false);
    }
}