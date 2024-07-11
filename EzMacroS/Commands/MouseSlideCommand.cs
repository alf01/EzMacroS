using System.Drawing;
using EzMacroS.Ivokers;

namespace EzMacroS.Commands
{
    public class MouseSlideCommand : ICommand
    {
        //MOVE
        public MouseSlideCommand(Point point)
        {
            Point = point;
        }

        public MouseSlideCommand(int x, int y)
        {
            Point = new Point(x, y);
        }

        public Point Point { get; }

        public void Execute()
        {
            Invoker.InvokeMouseMoveEvent(Point, true);
        }
    }
}