using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace ScreenDropper.Model
{
   public  class ScreenCapture
    {
       //This class is used to take screen shots of the desktop and convert them to the BitmapSource


       //This method takes screen shot of the specified region of the desktop
        public BitmapSource CaptureRegion(IntPtr hWnd, int x, int y, int width, int height, bool addToClipboard)
         {
          IntPtr sourceDC = IntPtr.Zero;
          IntPtr targetDC = IntPtr.Zero;
          IntPtr compatibleBitmapHandle = IntPtr.Zero;
          BitmapSource bitmap = null;
 
         try
         {
           // gets the main desktop and all open windows
           sourceDC = User32.GetDC(User32.GetDesktopWindow());
           targetDC = Gdi32.CreateCompatibleDC(sourceDC);
 
           // create a bitmap compatible with our target DC
           compatibleBitmapHandle = Gdi32.CreateCompatibleBitmap(sourceDC, width, height);
 
           // gets the bitmap into the target device context
           Gdi32.SelectObject(targetDC, compatibleBitmapHandle);
 
           // copy from source to destination
           Gdi32.BitBlt(targetDC, 0, 0, width, height, sourceDC, x, y, Gdi32.SRCCOPY);
 
           // Here's the WPF glue to make it all work. It converts from an
           // hBitmap to a BitmapSource. Love the WPF interop functions
           bitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            compatibleBitmapHandle, IntPtr.Zero, Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
          }
         catch (Exception ex)
         {
           throw new Exception(string.Format("Error capturing region {0},{1},{2},{3}", x, y, width, height), ex);
         }
        finally
        {
           Gdi32.DeleteObject(compatibleBitmapHandle);
 
           User32.ReleaseDC(IntPtr.Zero, sourceDC);
           User32.ReleaseDC(IntPtr.Zero, targetDC);
        }
 
        return bitmap;
      }

       //This method uses CaptureRegion to take the screen shot of the whole desktop
        public BitmapSource CaptureScreen()
        {
            BitmapSource bitmap = CaptureRegion(User32.GetDesktopWindow(), (int)SystemParameters.VirtualScreenLeft,
                (int)SystemParameters.VirtualScreenTop, (int)SystemParameters.VirtualScreenWidth, (int)SystemParameters.VirtualScreenHeight, false);
            return bitmap;
        }
  }
}
