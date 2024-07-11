using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EzMacroS.Conditions
{
    public partial class CaptureForm : Form
    {
        private readonly Bitmap _prntScreen;

        private bool _captureStarted;
        private int _endX;
        private int _endY;

        private int _startX;
        private int _startY;
        public Bitmap CapturedImage = new Bitmap(1, 1);

        public Point CaptureLocation;

        public CaptureForm()
        {
            _prntScreen = ImageHelper.GetScreen();

            InitializeComponent();
            // BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            TopMost = true;

            pictureBox1.Image = _prntScreen;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //  throw new System.NotImplementedException();

            _startX = e.X;
            _startY = e.Y;

            _captureStarted = true;

            //left top
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //  throw new System.NotImplementedException();

            _endX = e.X;
            _endY = e.Y;


            var croprect = new Rectangle(Math.Min(_startX, _endX), Math.Min(_startY, _endY), Math.Abs(_startX - _endX), Math.Abs(_startY - _endY));

            CapturedImage = ImageHelper.CropImage(_prntScreen, croprect);

            CaptureLocation = new Point(croprect.X, croprect.Y);

            DialogResult = DialogResult.OK;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_captureStarted)
            {
                var drawBmp = new Bitmap(_prntScreen);

                using (var graphics = Graphics.FromImage(drawBmp))
                {
                    using (var myBrush = new Pen(Color.Red))
                    {
                        myBrush.DashStyle = DashStyle.Dash;
                        graphics.DrawRectangle(myBrush, new Rectangle(Math.Min(_startX, e.X), Math.Min(_startY, e.Y), Math.Abs(_startX - e.X), Math.Abs(_startY - e.Y))); // whatever
//                        
//                        Color customColor = Color.FromArgb(50, Color.Red);
//                        SolidBrush shadowBrush = new SolidBrush(customColor);
//                        graphics.FillRectangles(shadowBrush, new RectangleF[]{rectFToFill});

                        // and so on...
                    } // myBrush will be disposed at this line

                    // bitmap.Save(fileName);
                }

                pictureBox1.Image = drawBmp;
                //mouse moving
            }
        }
    }
}