using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork.Data
{
    public static class MnistLoader
    {
        private const string TrainImagesPath = @".\Resources\MNIST\train-images.idx3-ubyte";

        

        public static void LoadData(PictureBox p)
        {
            var byteArray = File.ReadAllBytes(TrainImagesPath);
            var magicNumber = byteArray.ToInt32(0);
            var imageCount = byteArray.ToInt32(4);
            var rowCount = byteArray.ToInt32(8);
            var columnCount = byteArray.ToInt32(12);
            var byteImages = new List<byte[]>(imageCount);
            var pointIndex = 16;
            var imageSize = rowCount * columnCount;
            for (int imageIndex = 0; imageIndex < imageCount; imageIndex++)
            {
                var byteImage = new byte[rowCount * columnCount];
                for (int i = 0; i < imageSize; i++, pointIndex++)
                {
                    byteImage[i] = byteArray[pointIndex];
                }
                byteImages.Add(byteImage);
            }
            var t = byteImages[2];

            var image1 = t.ToImage(columnCount, rowCount);
            var image = t.ToBitmap(columnCount, rowCount);
            p.Image = image1;
        }
    }
}
