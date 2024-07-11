namespace EzMacroS.Commands
{
    public class PrintCommand:ICommand
    {
        public PrintCommand(string printString)
        {
            PrintString = printString;
        }
        public string PrintString { get; private set; }
        public void Execute()
        {
          
            
//                 foreach (var item in codestring)
//                {
//                    if (item == '/')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(111)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(111)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//
//                    else if (item == '*')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(106)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(106)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//
//                    else if (item == '+')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(107)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(107)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == '-')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(109)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(109)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == '!')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(13)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(13)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == '[') //shiftdown
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(16)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            //  keybd_event((Convert.ToByte(Convert.ToByte(13))), 0, 0x2, 0);
//                            //  Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == ']') //shiftup
//                    {
//                        try
//                        {
//                            // keybd_event((Convert.ToByte(Convert.ToByte(16))), 0, 0, 0);
//                            //Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(16)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//
//                    else if (item == '(') //ctrldown
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(17)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            //  keybd_event((Convert.ToByte(Convert.ToByte(13))), 0, 0x2, 0);
//                            //  Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == ')') //ctrlup
//                    {
//                        try
//                        {
//                            // keybd_event((Convert.ToByte(Convert.ToByte(16))), 0, 0, 0);
//                            //Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(17)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//
//                    else if (item == '{') //altdown
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(18)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            //  keybd_event((Convert.ToByte(Convert.ToByte(13))), 0, 0x2, 0);
//                            //  Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == '}') //altup
//                    {
//                        try
//                        {
//                            // keybd_event((Convert.ToByte(Convert.ToByte(16))), 0, 0, 0);
//                            //Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(18)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//
//                    else if (item == '.')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(190)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(190)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == ',')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(188)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(188)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == '=')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(187)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(187)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else if (item == ' ')
//                    {
//                        try
//                        {
//                            keybd_event(Convert.ToByte(Convert.ToByte(32)), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(32)), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                    else
//                    {
//                        try
//                        {
//                            //keybd_event((Convert.ToByte(Convert.ToByte(KeysConverter.ConvertFromString(cmd[2])))), 0, 0, 0);
//                            keybd_event(Convert.ToByte(Convert.ToByte(Convert.ToByte(KeysConverter.ConvertFromString(item.ToString())))), 0, 0, 0);
//                            Thread.Sleep(1);
//                            keybd_event(Convert.ToByte(Convert.ToByte(KeysConverter.ConvertFromString(item.ToString()))), 0, 0x2, 0);
//                            Thread.Sleep(1);
//                        }
//                        catch (Exception)
//                        {
//                            MessageBox.Show(string.Format("невозможно выполнить комманду ошибка в строке #[{0}] - [{1}] - недопустимый символ [{2}]", curindex.ToString(), it1, item));
//                            checkBox1.Checked = false;
//                        }
//                    }
//                }
//            }
            
        }
    }
}