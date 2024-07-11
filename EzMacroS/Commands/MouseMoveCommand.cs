using System.Drawing;
using EzMacroS.Ivokers;

namespace EzMacroS.Commands
{
    public class MouseMoveCommand : ICommand
    {
        //MOVE
        public MouseMoveCommand(Point point)
        {
            Point = point;
        }

        public MouseMoveCommand(int x, int y)
        {
            Point = new Point(x, y);
        }

        public Point Point { get; }

        public void Execute()
        {
            Invoker.InvokeMouseMoveEvent(Point);
        }
    }
}