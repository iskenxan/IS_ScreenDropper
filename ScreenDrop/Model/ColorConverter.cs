using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ScreenDropper.Model
{
    // This class gets the color value of the specific pixel in the Bitmap by using its x and y coordinates
    public class ColorConverter
    {
        public Color GetColor(BitmapSource bitmap, int x, int y)
        {
            int stride = bitmap.PixelWidth * (bitmap.Format.BitsPerPixel / 8);
            int channelCount = bitmap.Format.Masks.Count(); // 4

            // Make sure we have at least 3 color channels.
            Debug.Assert(channelCount >= 3);

            byte[] pixel = new byte[channelCount]; // Holds color values of a single pixel.

            bitmap.CopyPixels(new Int32Rect(x, y, 1, 1), pixel, stride, 0); // Assigns color values of a single pixel to the pixel array

            Color singlePixel = new Color(); // Creates a new color object, and assigns the color values found in pixel array to it

            singlePixel.B = pixel[0];
            singlePixel.G = pixel[1];
            singlePixel.R = pixel[2];

            singlePixel.A = (channelCount >= 4) ? pixel[3] : (byte)255; // 0;

            return singlePixel;
        }
    }
}
