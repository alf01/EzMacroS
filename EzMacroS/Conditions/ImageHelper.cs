using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EzMacroS.Conditions
{
    public static class ImageHelper
    {
        public static Bitmap GetScreen()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                //bmp.Save("screenshot.png");  // saves the image
            }

            return bmp;
        }

        public static Bitmap CaptureArea(out Point capturepPoint)
        {
            Console.Beep(2000, 400);
            
            CaptureForm  frm = new CaptureForm();
            var result  = frm.ShowDialog();
           // if ( result == DialogResult.OK )
             //   MessageBox.Show ("User clicked OK button");
             capturepPoint = frm.CaptureLocation;
            return  frm.CapturedImage;
        }

        #region  Find Subimage in image

           public static Point? Find(Bitmap haystack, Bitmap needle)
        {
            if (null == haystack || null == needle)
            {
                return null;
            }
            if (haystack.Width < needle.Width || haystack.Height < needle.Height)
            {
                return null;
            }

            var haystackArray = GetPixelArray(haystack);
            var needleArray = GetPixelArray(needle);

            foreach (var firstLineMatchPoint in FindMatch(haystackArray.Take(haystack.Height - needle.Height), needleArray[0]))
            {
                if (IsNeedlePresentAtLocation(haystackArray, needleArray, firstLineMatchPoint, 1))
                {
                    return firstLineMatchPoint;
                }
            }

            return null;
        }

        private static int[][] GetPixelArray(Bitmap bitmap)
        {
            var result = new int[bitmap.Height][];
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            for (int y = 0; y < bitmap.Height; ++y)
            {
                result[y] = new int[bitmap.Width];
                Marshal.Copy(bitmapData.Scan0 + y*bitmapData.Stride, result[y], 0, result[y].Length);
            }

            bitmap.UnlockBits(bitmapData);

            return result;
        }

        private static IEnumerable<Point> FindMatch(IEnumerable<int[]> haystackLines, int[] needleLine)
        {
            var y = 0;
            foreach (var haystackLine in haystackLines)
            {
                for (int x = 0, n = haystackLine.Length - needleLine.Length; x < n; ++x)
                {
                    if (ContainSameElements(haystackLine, x, needleLine, 0, needleLine.Length))
                    {
                        yield return new Point(x, y);
                    }
                }
                y += 1;
            }
        }

        private static bool ContainSameElements(int[] first, int firstStart, int[] second, int secondStart, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                if (first[i + firstStart] != second[i + secondStart])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsNeedlePresentAtLocation(int[][] haystack, int[][] needle, Point point, int alreadyVerified)
        {
            //we already know that "alreadyVerified" lines already match, so skip them
            for (int y = alreadyVerified; y < needle.Length; ++y)
            {
                if ( ! ContainSameElements(haystack[y + point.Y], point.X, needle[y], 0, needle.Length))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
        
     

//        public static bool FindOnScreen(Bitmap findbmp, out Point point)
//        {
//            point = new Point();
//            var screenShot = GetScreen();
//            var lockScreen = new LockB(screenShot);
//            var lockFind = new LockB(findbmp);
//
//            bool found;
//            for (int w = 0; w < lockScreen.Width; w++)
//            {
//                for (int h = 0; h < lockScreen.Height; h++)
//                {
//                    
//                    var spx =  lockScreen.GetPixel(w, h);
//                    
//
//                    for (int fw = 0; fw < lockFind.Width; fw++)
//                    {
//                        for (int fh = 0; fh < lockFind.Height; fh++)
//                        {
//                           var fpx =  lockFind.GetPixel(fw, fh);
//
//                           if (fpx.ToArgb().Equals(spx.ToArgb()))
//                           {
//                               
//                           }
//                           else
//                           {
//                               
//                           }
//
//                        }
//                        
//                    }
//                    
//                    
//                }
//            }
//
//        }
//        
        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            //upperleft rectangle
            
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
            
            // Example use:     
//            Bitmap source = new Bitmap(@"C:\tulips.jpg");
//            Rectangle section = new Rectangle(new Point(12, 50), new Size(150, 150));
//
//            Bitmap CroppedImage = CropImage(source, section);
        }


       
    }
}