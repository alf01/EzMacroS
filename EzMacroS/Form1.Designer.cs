namespace EzMacroS
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.commandsTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.conditionsPage = new System.Windows.Forms.TabPage();
            this.sameLocationCheckBox = new System.Windows.Forms.CheckBox();
            this.saveConditionButton = new System.Windows.Forms.Button();
            this.captureConditionButton = new System.Windows.Forms.Button();
            this.conditionName = new System.Windows.Forms.TextBox();
            this.removeConditionButton = new System.Windows.Forms.Button();
            this.addConditionButton = new System.Windows.Forms.Button();
            this.conditionsComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.conditionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commandsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.conditionsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.conditionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.commandsListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.textBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "запись позиции щелчка мыши";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // commandsTextBox
            // 
            this.commandsTextBox.Location = new System.Drawing.Point(8, 18);
            this.commandsTextBox.Multiline = true;
            this.commandsTextBox.Name = "commandsTextBox";
            this.commandsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commandsTextBox.Size = new System.Drawing.Size(198, 490);
            this.commandsTextBox.TabIndex = 2;
            this.commandsTextBox.TextChanged += new System.EventHandler(this.commandsTextBox_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(407, 31);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(167, 23);
            this.textBox3.TabIndex = 3;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(238, 464);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(239, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Активировать/Деактивировать макрос";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(407, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Загрузить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "КОД! клавиши активации ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "записать нажатие клавиши";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(238, 489);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(210, 19);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "режим 1 раз нажал и цикл пашет";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(238, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(335, 27);
            this.button4.TabIndex = 12;
            this.button4.Text = "запись смещения мыши (2 клика)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(405, 87);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(168, 44);
            this.button6.TabIndex = 14;
            this.button6.Text = "Запись всех действий мыши и клавиатуры";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(407, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(133, 19);
            this.checkBox3.TabIndex = 15;
            this.checkBox3.Text = "использовать SLIDE";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(580, 482);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(33, 23);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "play speed";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(238, 156);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(149, 25);
            this.button7.TabIndex = 18;
            this.button7.Text = "save mouse pos";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(405, 156);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(168, 25);
            this.button8.TabIndex = 19;
            this.button8.Text = "load mouse pos";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 528);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 23);
            this.comboBox1.TabIndex = 20;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.mainPage);
            this.tabControl2.Controls.Add(this.conditionsPage);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(722, 603);
            this.tabControl2.TabIndex = 21;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.panel1);
            this.mainPage.Controls.Add(this.textBox1);
            this.mainPage.Controls.Add(this.button1);
            this.mainPage.Controls.Add(this.comboBox1);
            this.mainPage.Controls.Add(this.commandsTextBox);
            this.mainPage.Controls.Add(this.button8);
            this.mainPage.Controls.Add(this.textBox3);
            this.mainPage.Controls.Add(this.button7);
            this.mainPage.Controls.Add(this.checkBox1);
            this.mainPage.Controls.Add(this.label4);
            this.mainPage.Controls.Add(this.button2);
            this.mainPage.Controls.Add(this.textBox4);
            this.mainPage.Controls.Add(this.button3);
            this.mainPage.Controls.Add(this.checkBox3);
            this.mainPage.Controls.Add(this.label1);
            this.mainPage.Controls.Add(this.button6);
            this.mainPage.Controls.Add(this.label3);
            this.mainPage.Controls.Add(this.button4);
            this.mainPage.Controls.Add(this.checkBox2);
            this.mainPage.Location = new System.Drawing.Point(4, 24);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(714, 575);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "MainPage";
            this.mainPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(238, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 165);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // conditionsPage
            // 
            this.conditionsPage.Controls.Add(this.button5);
            this.conditionsPage.Controls.Add(this.sameLocationCheckBox);
            this.conditionsPage.Controls.Add(this.saveConditionButton);
            this.conditionsPage.Controls.Add(this.captureConditionButton);
            this.conditionsPage.Controls.Add(this.conditionName);
            this.conditionsPage.Controls.Add(this.removeConditionButton);
            this.conditionsPage.Controls.Add(this.addConditionButton);
            this.conditionsPage.Controls.Add(this.conditionsComboBox);
            this.conditionsPage.Controls.Add(this.pictureBox1);
            this.conditionsPage.Location = new System.Drawing.Point(4, 24);
            this.conditionsPage.Name = "conditionsPage";
            this.conditionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.conditionsPage.Size = new System.Drawing.Size(714, 575);
            this.conditionsPage.TabIndex = 1;
            this.conditionsPage.Text = "ConditionsPage";
            this.conditionsPage.UseVisualStyleBackColor = true;
            // 
            // sameLocationCheckBox
            // 
            this.sameLocationCheckBox.Location = new System.Drawing.Point(122, 58);
            this.sameLocationCheckBox.Name = "sameLocationCheckBox";
            this.sameLocationCheckBox.Size = new System.Drawing.Size(147, 31);
            this.sameLocationCheckBox.TabIndex = 7;
            this.sameLocationCheckBox.Text = "Find in same location";
            this.sameLocationCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveConditionButton
            // 
            this.saveConditionButton.Location = new System.Drawing.Point(24, 106);
            this.saveConditionButton.Name = "saveConditionButton";
            this.saveConditionButton.Size = new System.Drawing.Size(75, 23);
            this.saveConditionButton.TabIndex = 6;
            this.saveConditionButton.Text = "Save";
            this.saveConditionButton.UseVisualStyleBackColor = true;
            this.saveConditionButton.Click += new System.EventHandler(this.saveConditionButton_Click);
            // 
            // captureConditionButton
            // 
            this.captureConditionButton.Location = new System.Drawing.Point(23, 61);
            this.captureConditionButton.Name = "captureConditionButton";
            this.captureConditionButton.Size = new System.Drawing.Size(75, 23);
            this.captureConditionButton.TabIndex = 5;
            this.captureConditionButton.Text = "capture";
            this.captureConditionButton.UseVisualStyleBackColor = true;
            this.captureConditionButton.Click += new System.EventHandler(this.captureConditionButton_Click);
            // 
            // conditionName
            // 
            this.conditionName.Location = new System.Drawing.Point(23, 22);
            this.conditionName.Name = "conditionName";
            this.conditionName.Size = new System.Drawing.Size(235, 23);
            this.conditionName.TabIndex = 4;
            // 
            // removeConditionButton
            // 
            this.removeConditionButton.Location = new System.Drawing.Point(348, 533);
            this.removeConditionButton.Name = "removeConditionButton";
            this.removeConditionButton.Size = new System.Drawing.Size(75, 23);
            this.removeConditionButton.TabIndex = 3;
            this.removeConditionButton.Text = "Remove";
            this.removeConditionButton.UseVisualStyleBackColor = true;
            // 
            // addConditionButton
            // 
            this.addConditionButton.Location = new System.Drawing.Point(257, 532);
            this.addConditionButton.Name = "addConditionButton";
            this.addConditionButton.Size = new System.Drawing.Size(75, 23);
            this.addConditionButton.TabIndex = 2;
            this.addConditionButton.Text = "Add";
            this.addConditionButton.UseVisualStyleBackColor = true;
            this.addConditionButton.Click += new System.EventHandler(this.addConditionButton_Click);
            // 
            // conditionsComboBox
            // 
            this.conditionsComboBox.FormattingEnabled = true;
            this.conditionsComboBox.Location = new System.Drawing.Point(23, 533);
            this.conditionsComboBox.Name = "conditionsComboBox";
            this.conditionsComboBox.Size = new System.Drawing.Size(203, 23);
            this.conditionsComboBox.TabIndex = 1;
            this.conditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.conditionsComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(276, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 307);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 147);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(234, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Insert Condition to code";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 603);
            this.Controls.Add(this.tabControl2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tabControl2.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.conditionsPage.ResumeLayout(false);
            this.conditionsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.conditionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.commandsListBindingSource)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage conditionsPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox conditionsComboBox;
        private System.Windows.Forms.Button addConditionButton;
        private System.Windows.Forms.Button removeConditionButton;
        private System.Windows.Forms.Button captureConditionButton;
        private System.Windows.Forms.Button saveConditionButton;
        private System.Windows.Forms.BindingSource conditionsBindingSource;
        private System.Windows.Forms.TextBox conditionName;
        private System.Windows.Forms.BindingSource commandsListBindingSource;
        private System.Windows.Forms.TextBox commandsTextBox;
        private System.Windows.Forms.CheckBox sameLocationCheckBox;
        private System.Windows.Forms.Button button5;
    }
}

