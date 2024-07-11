using System;
using System.Runtime.InteropServices;

namespace EzMacroS.Ivokers
{
    public class User32KeyBoardInvoker : IKeyboardInvoker
    {
        public void ExecuteKey(bool isDown, byte keyCode)
        {
            if (isDown)
            {
                // byte key = Convert.ToByte(Convert.ToByte(cmd[2]));
                try
                {
                    keybd_event(keyCode, 0, 0, 0); //int i = 5 + rnd.Next(10);                               
                }
                catch (Exception ex)
                {
//                    MessageBox.Show( String.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}]", curindex.ToString(), it1));
//                    checkBox1.Checked = false;
                }
            }
            else
            {
                keybd_event(keyCode, 0, 0x2, 0);
            }
        }

        [DllImport("user32.dll")]
        private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    }
}