using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace NeuralNetwork.Data
{
    public static class ByteArrayExtensions
    {
        public static int ToInt32(this byte[] byteArray, int startIndex)
        {
            if (BitConverter.IsLittleEndian)
            {
                var reversed = byteArray.Skip(startIndex).Take(4).Reverse().ToArray();
                return BitConverter.ToInt32(reversed, 0);
            }
            return BitConverter.ToInt32(byteArray, startIndex);
        }

        public static Image ToImage(this byte[] pixels, int width, int height) => 
            FillWithFakeBytes(pixels).ImageFromRawBgraArray(width, height, PixelFormat.Format24bppRgb);

        public static Image ToBitmap(this byte[] pixels, int width, int height)
        {
            int pixel = 0;
            Bitmap bmap = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int colour = 255 - pixels[pixel];
                    bmap.SetPixel(j, i, Color.FromArgb(colour, colour, colour));
                    pixel++;
                }
            }
            return bmap;
        }

        private static IEnumerable<byte> FillWithFakeBytesInternal(IEnumerable<byte> original)
        {
            foreach (var o in original)
            {
                var t = (byte)~o;
                yield return t;
                yield return t;
                yield return t;
            }
        }

        private static byte[] FillWithFakeBytes(byte[] original) => FillWithFakeBytesInternal(original).ToArray();

        // WTF?
        private static Image ImageFromRawBgraArray(this byte[] arr, int width, int height, PixelFormat pixelFormat)
        {
            var output = new Bitmap(width, height, pixelFormat);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);

            // Row-by-row copy
            var arrRowLength = width * Image.GetPixelFormatSize(output.PixelFormat) / 8;
            var ptr = bmpData.Scan0;
            for (var i = 0; i < height; i++)
            {
                Marshal.Copy(arr, i * arrRowLength, ptr, arrRowLength);
                ptr += bmpData.Stride;
            }

            output.UnlockBits(bmpData);
            return output;
        }

        
    }
}
