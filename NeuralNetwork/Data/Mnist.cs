using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork.Data
{
    public class Mnist
    {
        private const string TrainImagesPath = @".\Resources\MNIST\train-images.idx3-ubyte";
        private const string TrainLabelsPath = @".\Resources\MNIST\train-labels.idx1-ubyte";
        private const string TestImagesPath = @".\Resources\MNIST\t10k-images.idx3-ubyte";
        private const string TestLabelsPath = @".\Resources\MNIST\t10k-labels.idx1-ubyte";
        private const int Width = 28;
        private const int Height = 28;

        public static List<byte[]> TrainImages = LoadImages(TrainImagesPath);
        public static List<byte> TrainLabels = LoadLabels(TrainLabelsPath);

        public static List<byte[]> TestImages = LoadImages(TestImagesPath);
        public static List<byte> TestLabels = LoadLabels(TestLabelsPath);

        private static List<byte> LoadLabels(string path)
        {
            var byteArray = File.ReadAllBytes(path);
            var magicNumber = byteArray.ToInt32(0);
            var labelsCount = byteArray.ToInt32(4);
            var labels = new List<byte>(labelsCount);
            var labelIndex = 8;
            for (int i = 0; i < labelsCount; i++)
            {
                labels.Add(byteArray[labelIndex++]);
            }
            return labels;
        }

        private static List<byte[]> LoadImages(string path)
        {
            var byteArray = File.ReadAllBytes(path);
            var magicNumber = byteArray.ToInt32(0);
            var imageCount = byteArray.ToInt32(4);
            var height = byteArray.ToInt32(8);
            var width = byteArray.ToInt32(12);
            var byteImages = new List<byte[]>(imageCount);
            var pointIndex = 16;
            var imageSize = height * width;
            for (int imageIndex = 0; imageIndex < imageCount; imageIndex++)
            {
                var byteImage = new byte[height * width];
                for (int i = 0; i < imageSize; i++, pointIndex++)
                {
                    byteImage[i] = byteArray[pointIndex];
                }
                byteImages.Add(byteImage);
            }
            return byteImages;
        }

        private static void Draw(PictureBox p, byte[] imageBytes, byte label)
        {
            using (var image = imageBytes.ToImage(Width, Height))
            using (var g = Graphics.FromImage(p.Image))
            {
                g.DrawImage(image, 0, 0);
                g.DrawString(label.ToString(), new Font("Arial", 20), Brushes.Black, p.Width - 20 , 0);
            }
        }

        public static void DrawTrain(PictureBox p, int index)
        {
            var imageBytes = TrainImages[index];
            var label = TrainLabels[index];
            Draw(p, imageBytes, label);
        }

        public static void DrawTest(PictureBox p, int index)
        {
            var imageBytes = TestImages[index];
            var label = TestLabels[index];
            Draw(p, imageBytes, label);
        }
    }
}
