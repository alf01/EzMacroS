using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace EzMacroS.Conditions
{
    [Serializable]
    public class PictureBaseCondition : BaseCondition
    {
        //picture as bytearray?
       // public string ConditionName { get; set; }
        [XmlIgnore]
        public Bitmap ConditionImage { get; set; }

        public bool FindInSameLocation { get; set; }
        
        /// <summary>
        /// параметр с инфой если требуется что бы найденый кусок был там же а не на всем экране
        /// </summary>
        public Point CaptureLocation { get; set; }

        /// <summary>
        /// специальное значение для общего буфера блока условия выполнения что бы туда можно было сдвинуть мышь например
        /// </summary>
        public Point FoundLocation { get; set; }
        
        [XmlElement("ImageBytes")]
        public byte[] ConditionImageBytes
        {
            get { // serialize

                byte[] returnBytes;
                if (ConditionImage == null) return null;
                using (MemoryStream ms = new MemoryStream()) {
                    ConditionImage.Save(ms, ImageFormat.Bmp);
                    returnBytes =  ms.ToArray();
                    
                }

                return returnBytes;
            }
            set { // deserialize
                if (value == null) {
                    ConditionImage = null;
                } else {
                    using (MemoryStream ms = new MemoryStream(value)) {
                        ConditionImage = new Bitmap(ms);
                    }
                }
            }
        }

        public override bool CalculateCondition()
        {
            //throw new System.NotImplementedException();

            Bitmap findScreen;

            if (FindInSameLocation)
            {
                findScreen = ImageHelper.CropImage(ImageHelper.GetScreen(), new Rectangle(CaptureLocation.X, CaptureLocation.Y, ConditionImage.Width+1, ConditionImage.Height+1)); //+1 потому что подляна с алгоритмом сравнения туду курнуть детальнее алгоритм поиска картинке в подкартинке
            }
            else
            {
                findScreen = ImageHelper.GetScreen();
            }

            var fResult = ImageHelper.Find(findScreen, ConditionImage);

            if (fResult.HasValue)
            {
                FoundLocation = fResult.Value;
                return true;
            }

            return false;
        }

       
    }
}