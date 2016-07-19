using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ScreenDropper.Model
{
    //This class gets the color value of the specific pixel in the Bitmap by using it's x and y coordinates
   public  class ColorConverter
    {
        public Color GetColor(BitmapSource bitmap,int x,int y)
        {
            List<string> hashCode= new List<string>();
            int stride = bitmap.PixelWidth * (bitmap.Format.BitsPerPixel / 8);
                    byte[] pixel = new byte[bitmap.PixelHeight];//holds color values of a single pixel
                    bitmap.CopyPixels(new Int32Rect(x,y,1,1), pixel, stride, 0);//assigns color values of a single pixel to the pixel array
                    Color singlePixel = new Color();//creates new color objects and assigns the color values found in pixel array to it
                    singlePixel.B = pixel[0];
                    singlePixel.G = pixel[1];
                    singlePixel.R = pixel[2];
                    singlePixel.A = pixel[3];
                    return singlePixel;
        }
    }
}
