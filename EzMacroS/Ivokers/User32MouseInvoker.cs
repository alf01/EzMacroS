using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EzMacroS.Ivokers
{
    public class User32MouseInvoker : IMouseInvoker
    {
        private const byte MOUSEEVENTF_LEFTDOWN = 0x02;
        private const byte MOUSEEVENTF_LEFTUP = 0x04;
        private const byte MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const byte MOUSEEVENTF_RIGHTUP = 0x10;
        private const byte MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const byte MOUSEEVENTF_MIDDLEUP = 0x0040;

        public void ExecuteKey(bool isDown, MouseKeys keyCode)
        {
            byte executeCode = 0x00;
            if (isDown)
            {
                switch (keyCode)
                {
                    case MouseKeys.Left:
                        executeCode = MOUSEEVENTF_LEFTDOWN;
                        break;
                    case MouseKeys.Right:
                        executeCode = MOUSEEVENTF_RIGHTDOWN;
                        break;
                    case MouseKeys.Middle:
                        executeCode = MOUSEEVENTF_MIDDLEDOWN;
                        break;
                }
            }
            else
            {
                switch (keyCode)
                {
                    case MouseKeys.Left:
                        executeCode = MOUSEEVENTF_LEFTUP;
                        break;
                    case MouseKeys.Right:
                        executeCode = MOUSEEVENTF_RIGHTUP;
                        break;
                    case MouseKeys.Middle:
                        executeCode = MOUSEEVENTF_MIDDLEUP;
                        break;
                }
            }

            mouse_event(executeCode, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }


        public void ExecuteMove(Point point, bool isSlide = false)
        {
            if (point.IsEmpty)
            {
                throw new NotImplementedException();
            }

            if (!isSlide)
            {
                // Point NewPosition = new Point(Convert.ToInt32(cmd[2]), Convert.ToInt32(cmd[3]));
                if (point != Cursor.Position)
                {
                    Cursor.Position = point;
                    //new Point(Convert.ToInt32(cmd[2]), Convert.ToInt32(cmd[3]));
                }
            }
            else
            {
                if (point.X != 0 || point.Y != 0)
                {
                    Cursor.Position = new Point(Cursor.Position.X + point.X, Cursor.Position.Y + point.Y);
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    }
}