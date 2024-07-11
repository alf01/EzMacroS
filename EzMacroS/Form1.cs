using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using EzMacroS.Commands;
using EzMacroS.Conditions;

namespace EzMacroS
{
    public partial class Form1 : Form
    {
        private readonly List<int> Buttonsisdown = new List<int>();

        private readonly int _activeMacroUnitIndex = 0;

        private Bitmap _lastCapturedImage;

        private Point _lastCapturedpoint;

        private MacroBase _macroBase; //= new MacroBase();

        private KeysConverter KeysConverter;

        private double playSpeed = 1;
        public bool work2status;

        private Thread working;
        private bool workingWasInit;
        private bool WriteSlideNotMove;
        private Thread writing;
        private bool writingWasInit;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = e.KeyValue.ToString();

            _macroBase.MacrosList[_activeMacroUnitIndex].BindInt = e.KeyValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string btn;
            int x, y;

            GetMouseInfo(out btn, out x, out y);

            {
                commandsTextBox.AppendText("MOUSE_MOVE_" + x + "_" + y + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
                commandsTextBox.AppendText("MOUSE_" + btn.ToUpper() + "_DOWN" + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
                commandsTextBox.AppendText("MOUSE_" + btn.ToUpper() + "_UP" + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
            }
        }

        private void GetMouseInfo(out string btn, out int x, out int y)
        {
            btn = "left";
            x = 0;
            y = 1;
            var btnPressed = false;

            GetAsyncKeyState(1);
            while (btnPressed == false)
            {
                if (GetAsyncKeyState(1) != 0)
                {
                    btnPressed = true;

                    btn = "left";

                    x = Cursor.Position.X;
                    y = Cursor.Position.Y;
                }
                else if (GetAsyncKeyState(2) != 0)
                {
                    btnPressed = true;

                    btn = "right";

                    x = Cursor.Position.X;
                    y = Cursor.Position.Y;
                }
            }

            GetAsyncKeyState(1);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _macroBase = new MacroBase();
            _macroBase.MacrosList.Add(new MacroUnit());
            label2.Text = "Гайд: \r\n 1. нажать на поле \"КОД клавиши активации\" \r\n 2. Нажать на клавишу на клавиатуре (появится код) \r\n 3. записать каждый отдельный клик мыши \r\n 4. записать нажатие кнопок через поле записи \r\n 5. запустить макрос \r\n 6. макрос можно редактировать \r\n 7. в комманде SLEEP время в милисекундах\r\n 8. F12 экстренная отмена макроса или записи действий \r\n 9. PPRINT_ [] - Shift, () - Ctrl, {} - Alt, ! - ENTER";
            KeysConverter = new KeysConverter();

            conditionsBindingSource.DataSource = _macroBase.ConditionList;
            conditionsComboBox.DataSource = conditionsBindingSource;
            conditionsComboBox.DisplayMember = "ConditionName";
            conditionsComboBox.ValueMember = "ConditionName";
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            textBox3.Text = "";
            textBox3.Text = e.KeyCode.ToString();
            commandsTextBox.AppendText("KEY_DOWN_" + KeysConverter.ConvertToString(e.KeyValue) + Environment.NewLine);
            commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            textBox3.Text = "";
            textBox3.Text = e.KeyCode.ToString();

            commandsTextBox.AppendText("KEY_UP_" + KeysConverter.ConvertToString(e.KeyValue) + Environment.NewLine);
            commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                playSpeed = Convert.ToDouble(textBox4.Text);
                if (playSpeed < 0)
                {
                    playSpeed = 1;
                    textBox4.Text = "1";
                }
            }
            catch (Exception)
            {
                textBox4.Text = "1";
                MessageBox.Show("указывайте дробную скорость через запятую");
            }

            if (checkBox1.Checked)
            {
                if (textBox1.Text.Length < 1)
                {
                    MessageBox.Show("не введена клавиша активации, какой кнопкой ты собрался активировать свой макрос?");
                    checkBox1.Checked = false;
                }
                else if (commandsTextBox.Text.Length < 1)
                {
                    MessageBox.Show("не введен ни один параметр макроса, нечего активировать!");
                    checkBox1.Checked = false;
                }
                else if (writingWasInit)
                {
                    MessageBox.Show("не остановлен поток записи макроса, клавиша - F12");
                    checkBox1.Checked = false;
                }
                else
                {
                    //внешний вид
                    textBox1.Enabled = false;
                    commandsTextBox.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button6.Enabled = false;


                    // var doList = new List<string>(commandsTextBox.Text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries));
                    var doList = _macroBase.MacrosList[_activeMacroUnitIndex].CommandList;

                    var scriptLogic = new ScriptLogic(_macroBase.MacrosList[_activeMacroUnitIndex].BindInt, CommandConverter.ConvertToCommands(doList, playSpeed, _macroBase.ConditionList));

                    // textBox2.Text = "";
                    var recurs = false;

                    RecursiveCheckCmd(scriptLogic.CommandsList);

                    void RecursiveCheckCmd(List<ICommand> commands)
                    {
                        foreach (var cmd in commands)
                        {
                            if (cmd is ICommandWithSubCommands subCommands)
                            {
                                RecursiveCheckCmd(subCommands.ConditionCommands);
                            }

                            if (cmd is KeyCommand keyCmd && keyCmd.KeyCode == Convert.ToByte(scriptLogic.BindInt))
                            {
                                recurs = true;
                                break;
                            }
                        }
                    }

                    working = new Thread(work);
                    working.Start(scriptLogic);
                    workingWasInit = true;
                    if (recurs)
                    {
                        working.Abort();
                        workingWasInit = false;
                        MessageBox.Show("РЕКУРСИЯ! в коде срипта есть совпадение с кодом клавиши вызова это вызовет залипание");

                        checkBox1.Checked = false;
                    }
                }
            }
            else
            {
                work2status = false;
                textBox1.Enabled = true;
                commandsTextBox.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                if (workingWasInit)
                {
                    working.Abort();
                }
            }
        }

        private void write()
        {
            long lasttick = 0;
            var lastmousepoint = new Point(-1, -1);
            while (true)
            {
                var btn = 0;
                var isdown = true;
                GetAnyKeyInfo(out btn, out isdown);
                if (btn == 0)
                {
                    MessageBox.Show("ошибка индекс кнопки = 0");
                }
                else if (btn == 123)
                {
                    //добавить прерыватель под f12
                    //break;
                }
                else if (btn == 1)
                {
                    var currentDate = DateTime.Now;
                    var curtick = currentDate.Ticks;
                    long newsleep = 50;
                    if (lasttick != 0)
                    {
                        //вписать слип с прошлой коммандой
                        newsleep = Convert.ToInt64(Math.Round(Convert.ToDouble((curtick - lasttick) / 10000 / 2)));
                        //textBox2.AppendText("SLEEP_"+newsleep + Environment.NewLine);
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));
                    }

                    if (lastmousepoint == new Point(-1, -1))
                    {
                        var curpoint = Cursor.Position;
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MOVE_" + curpoint.X + "_" + curpoint.Y + Environment.NewLine)));
                        lastmousepoint = curpoint;
                    }
                    else
                    {
                        var curpoint = Cursor.Position;
                        if (WriteSlideNotMove == false)
                        {
                            commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MOVE_" + curpoint.X + "_" + curpoint.Y + Environment.NewLine)));
                        }
                        else
                        {
                            commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_SLIDE_" + (curpoint.X - lastmousepoint.X) + "_" + (curpoint.Y - lastmousepoint.Y) + Environment.NewLine)));
                        }

                        //подумать об альтернативном варианте без слайдов с чистыми мувами а так же добавить проверку слайд 0 0 
                        lastmousepoint = curpoint;
                    }

                    lasttick = curtick;
                    commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));

                    if (isdown)
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_LEFT_DOWN" + Environment.NewLine)));
                    }
                    else
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_LEFT_UP" + Environment.NewLine)));
                    }
                }
                else if (btn == 2)
                {
                    var currentDate = DateTime.Now;
                    var curtick = currentDate.Ticks;
                    long newsleep = 50;
                    if (lasttick != 0)
                    {
                        //вписать слип с прошлой коммандой
                        newsleep = Convert.ToInt64(Math.Round(Convert.ToDouble((curtick - lasttick) / 10000 / 2)));
                        //textBox2.AppendText("SLEEP_"+newsleep + Environment.NewLine);
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));
                    }

                    if (lastmousepoint == new Point(-1, -1))
                    {
                        var curpoint = Cursor.Position;
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MOVE_" + curpoint.X + "_" + curpoint.Y + Environment.NewLine)));
                        lastmousepoint = curpoint;
                    }
                    else
                    {
                        var curpoint = Cursor.Position;
                        if (WriteSlideNotMove == false)
                        {
                            commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MOVE_" + curpoint.X + "_" + curpoint.Y + Environment.NewLine)));
                        }
                        else
                        {
                            commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_SLIDE_" + (curpoint.X - lastmousepoint.X) + "_" + (curpoint.Y - lastmousepoint.Y) + Environment.NewLine)));
                        }


                        lastmousepoint = curpoint;
                    }

                    lasttick = curtick;
                    commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));

                    if (isdown)
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_RIGHT_DOWN" + Environment.NewLine)));
                    }
                    else
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_RIGHT_UP" + Environment.NewLine)));
                    }
                }
                else if (btn == 4)
                {
                    var currentDate = DateTime.Now;
                    var curtick = currentDate.Ticks;
                    long newsleep = 50;
                    if (lasttick != 0)
                    {
                        //вписать слип с прошлой коммандой
                        newsleep = Convert.ToInt64(Math.Round(Convert.ToDouble((curtick - lasttick) / 10000 / 2)));
                        //textBox2.AppendText("SLEEP_"+newsleep + Environment.NewLine);
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));
                    }

                    if (lastmousepoint == new Point(-1, -1))
                    {
                        var curpoint = Cursor.Position;
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MOVE_" + curpoint.X + "_" + curpoint.Y + Environment.NewLine)));
                        lastmousepoint = curpoint;
                    }
                    else
                    {
                        var curpoint = Cursor.Position;
                        if (WriteSlideNotMove == false)
                        {
                            commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MOVE_" + curpoint.X + "_" + curpoint.Y + Environment.NewLine)));
                        }
                        else
                        {
                            commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_SLIDE_" + (curpoint.X - lastmousepoint.X) + "_" + (curpoint.Y - lastmousepoint.Y) + Environment.NewLine)));
                        }


                        lastmousepoint = curpoint;
                    }

                    lasttick = curtick;
                    commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));

                    if (isdown)
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MIDDLE_DOWN" + Environment.NewLine)));
                    }
                    else
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("MOUSE_MIDDLE_UP" + Environment.NewLine)));
                    }
                }
                else
                {
                    var currentDate = DateTime.Now;
                    var curtick = currentDate.Ticks;
                    if (lasttick != 0)
                    {
                        //вписать слип с прошлой коммандой
                        var newsleep = Convert.ToInt64(Math.Round(Convert.ToDouble((curtick - lasttick) / 10000)));
                        //textBox2.AppendText("SLEEP_"+newsleep + Environment.NewLine);
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("SLEEP_" + newsleep + Environment.NewLine)));
                    }

                    lasttick = curtick;


                    if (isdown)
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("KEY_DOWN_" + KeysConverter.ConvertToString(btn) + Environment.NewLine)));
                    }
                    else
                    {
                        commandsTextBox.Invoke(new Action(() => commandsTextBox.AppendText("KEY_UP_" + KeysConverter.ConvertToString(btn) + Environment.NewLine)));
                    }
                }
            }
        }

        public void GetAnyKeyInfo(out int btn, out bool isdown)
        {
            btn = 0;
            isdown = true;
            var ex = false;
            while (ex == false)
            {
                for (var i = 1; i < 230; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 0 && !Buttonsisdown.Contains(i))
                    {
                        Buttonsisdown.Add(i);
                        btn = i;
                        isdown = true;
                        ex = true;
                        break;
                    }

                    if (keyState == 0 && Buttonsisdown.Contains(i))
                    {
                        Buttonsisdown.RemoveAll(item => item == i);
                        btn = i;
                        isdown = false;
                        ex = true;
                        break;
                    }
                }
            }
        }

        private void work(object c)
        {
            if (!(c is ScriptLogic scriptLogic))
            {
                return;
            }

            while (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    //изменение статуса клавиши
                    if (GetAsyncKeyState(scriptLogic.BindInt) != 0)
                    {
                        if (work2status)
                        {
                            work2status = false;
                        }
                        else
                        {
                            work2status = true;
                        }

                        GetAsyncKeyState(scriptLogic.BindInt);
                        Thread.Sleep(450);
                        GetAsyncKeyState(scriptLogic.BindInt);
                    }
                }

                if (GetAsyncKeyState(scriptLogic.BindInt) != 0 && checkBox2.Checked == false || checkBox2.Checked && work2status)
                {
                    //foreach (string it1 in Dolist)
                    for (var j = 0; j < scriptLogic.CommandsList.Count; j++)
                    {
                        var it1 = scriptLogic.CommandsList[j];
                        //прерыватель по нажатию в режиме 1нажал-пашет
                        // DoCommand(it1, j);
                        it1.Execute();


                        if (checkBox2.Checked && work2status)
                        {
                            //GetAsyncKeyState(BindInt);
                            if (GetAsyncKeyState(_macroBase.MacrosList[_activeMacroUnitIndex].BindInt) != 0)
                            {
                                Console.Beep(2000, 400);
                                //work2status = false;
                                //GetAsyncKeyState(BindInt);

                                work2status = false;
                                GetAsyncKeyState(_macroBase.MacrosList[_activeMacroUnitIndex].BindInt);
                                Thread.Sleep(500);
                                GetAsyncKeyState(_macroBase.MacrosList[_activeMacroUnitIndex].BindInt);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  Dolist = new List<string>();
//          var Dolist = _macroBase.MacrosList[_activeMacroUnitIndex].CommandList;// new List<string>(commandsTextBox.Text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries));
//
//
//            var save = new SaveFileDialog();
//            save.FileName = "MacroS.txt";
//            save.Filter = "Text File | *.txt";
//            if (save.ShowDialog() == DialogResult.OK)
//            {
//                var writer = new StreamWriter(save.OpenFile());
//                writer.WriteLine("BIND_" + _macroBase.MacrosList[_activeMacroUnitIndex].BindInt);
//                for (var i = 0; i < Dolist.Count; i++)
//                {
//                    writer.WriteLine(Dolist[i]);
//                }
//
//                writer.Dispose();
//                writer.Close();
//            }

            var save = new SaveFileDialog();
            save.FileName = "MacroS.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                var xs = new XmlSerializer(typeof(MacroBase));
                var writer = new StreamWriter(save.FileName);
                // TextWriter txtWriter = new StreamWriter(@ "D:\Serialization.xml");
                xs.Serialize(writer, _macroBase);
                writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            commandsTextBox.Text = "";
            var theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var myStream = theDialog.OpenFile();
                    using (myStream)
                    {
                        //                         
                        var serializer = new XmlSerializer(typeof(MacroBase));

                        _macroBase = (MacroBase) serializer.Deserialize(myStream);

//                         
                        textBox1.Text = _macroBase.MacrosList[_activeMacroUnitIndex].BindInt.ToString();

                        conditionsBindingSource.DataSource = _macroBase.ConditionList;

                        commandsTextBox.Text = _macroBase.MacrosList[_activeMacroUnitIndex].Commands;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            checkBox1.Checked = false;
            //working = new Thread(work);
            if (workingWasInit)
            {
                if (working.ThreadState.ToString() == "Running")
                {
                    working.Abort();
                    workingWasInit = false;
                }
            }

            checkBox1.Checked = false;
            if (writingWasInit)
            {
                if (writing.ThreadState.ToString() == "Running")
                {
                    //Console.Beep(1000, 400);

                    writing.Abort();
                    writingWasInit = false;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            string btn1;
            int x1, y1;
            // GetMouseInfoThread = new Thread(GetMouseInfo(/*out btn,out x,out y*/));
            GetMouseInfo(out btn1, out x1, out y1);
            Thread.Sleep(200);
            string btn2;
            int x2, y2;
            // GetMouseInfoThread = new Thread(GetMouseInfo(/*out btn,out x,out y*/));
            GetMouseInfo(out btn2, out x2, out y2);
            // if (FromKeyPressSearch == 2)
            {
                commandsTextBox.AppendText("MOUSE_" + btn1.ToUpper() + "_DOWN" + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
                commandsTextBox.AppendText("MOUSE_" + btn1.ToUpper() + "_UP" + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
                commandsTextBox.AppendText("MOUSE_SLIDE_" + (x2 - x1) + "_" + (y2 - y1) + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
                commandsTextBox.AppendText("MOUSE_" + btn2.ToUpper() + "_DOWN" + Environment.NewLine);
                commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
                commandsTextBox.AppendText("MOUSE_" + btn2.ToUpper() + "_UP" + Environment.NewLine);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(123) != 0)
            {
                //working = new Thread(work);
                // writing = new Thread(write);
                if (workingWasInit)
                {
                    if (working.ThreadState.ToString() == "Running")
                    {
                        working.Abort();
                        workingWasInit = false;
                    }
                }

                checkBox1.Checked = false;
                if (writingWasInit)
                {
                    if (writing.ThreadState.ToString() == "Running")
                    {
                        Console.Beep(1000, 400);

                        writing.Abort();
                        writingWasInit = false;
                    }
                }
            }
        }

//        private void button5_Click(object sender, EventArgs e)
//        {
//            textBox2.AppendText("NEXT_" + 4 + "_REPEAT_" + 3 + Environment.NewLine);
//        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (var i = 1; i < 230; i++)
            {
                GetAsyncKeyState(i);
            }


            if (writingWasInit != true)
            {
                writing = new Thread(write);
                if (writing.ThreadState.ToString() != "Running")
                {
                    writing.Start(); // синхронизация потока
                    writingWasInit = true;
                }
            }

            //write();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            WriteSlideNotMove = checkBox3.Checked;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            commandsTextBox.AppendText("MOUSE_SAVE" + Environment.NewLine);
            commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            commandsTextBox.AppendText("MOUSE_LOAD" + Environment.NewLine);
            commandsTextBox.AppendText("SLEEP_50" + Environment.NewLine);
        }

        private void addConditionButton_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();

            //GlobalConditions.ConditionList.Add(new PictureCondition(){ConditionName = $"CND{ GlobalConditions.ConditionList.Count}"});
            _macroBase.ConditionList.Add(new PictureBaseCondition {ConditionName = $"CND{_macroBase.ConditionList.Count}"});
            conditionsComboBox.SelectedIndex = conditionsComboBox.Items.Count - 1;
            conditionsComboBox_SelectedIndexChanged(conditionsComboBox, EventArgs.Empty);
            // conditionsComboBox.
        }


        private void captureConditionButton_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();
//           var bmp = ImageHelper.GetScreen();
//
//           pictureBox1.Image = bmp;
            _lastCapturedImage = ImageHelper.CaptureArea(out _lastCapturedpoint);
            pictureBox1.Image = _lastCapturedImage;
        }

        private void saveConditionButton_Click(object sender, EventArgs e)
        {
            // throw new System.NotImplementedException();

            var selectedBaseCondition = (BaseCondition) conditionsComboBox.SelectedItem;
            if (selectedBaseCondition != null)
            {
                selectedBaseCondition.ConditionName = conditionName.Text;
                (selectedBaseCondition as PictureBaseCondition).ConditionImage = _lastCapturedImage;
                (selectedBaseCondition as PictureBaseCondition).CaptureLocation = _lastCapturedpoint;
                (selectedBaseCondition as PictureBaseCondition).FindInSameLocation = sameLocationCheckBox.Checked;
            }
        }

        private void conditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
            var selectedBaseCondition = (BaseCondition) conditionsComboBox.SelectedItem;
            if (selectedBaseCondition != null)
            {
                pictureBox1.Image = (selectedBaseCondition as PictureBaseCondition).ConditionImage;

                conditionName.Text = selectedBaseCondition.ConditionName;
            }
        }

        private void commandsTextBox_TextChanged(object sender, EventArgs e)
        {
            _macroBase.MacrosList[_activeMacroUnitIndex].Commands = commandsTextBox.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var selectedBaseCondition = (BaseCondition) conditionsComboBox.SelectedItem;
            
            commandsTextBox.AppendText("IF_"+ selectedBaseCondition.ConditionName+ ""+ Environment.NewLine);
            commandsTextBox.AppendText("ENDIF_"+ selectedBaseCondition.ConditionName+ ""+ Environment.NewLine);
           
        }
    }
}