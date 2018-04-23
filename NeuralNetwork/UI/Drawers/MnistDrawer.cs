using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NeuralNetwork.Data;

namespace NeuralNetwork.UI.Drawers
{
    public class MnistDrawer : IDrawer
    {
        private readonly List<double> input;
        private readonly List<double> expected;
        private readonly List<double> actual;

        public MnistDrawer(List<double> input, List<double> expected, List<double> actual)
        {
            this.input = input;
            this.expected = expected;
            this.actual = actual;
        }

        private static byte ListToLabel(List<double> list)
        {
            var m = list.Max();
            return (byte)list.IndexOf(m);
        }

        public void Draw(PictureBox p)
        {
            var imageBytes = input.Select(x => (byte)(x * 255)).ToArray();

            var expectedLabel = ListToLabel(expected);

            var actualLabel = ListToLabel(actual);
            var confidence = actual.Max();
            var resultBrush = actualLabel == expectedLabel ? Brushes.Green : Brushes.OrangeRed;

            var actualExceptBest = actual.Select(x => x != confidence ? x : -1).ToList();
            var actualLabel2 = ListToLabel(actualExceptBest);
            var confidence2 = actualExceptBest.Max();
            var resultBrush2 = actualLabel == expectedLabel
                ? Brushes.Black
                : actualLabel2 == expectedLabel ? Brushes.Green : Brushes.OrangeRed;

            var font = new Font("Arial", 20);

            using (var image = imageBytes.ToImage(28, 28))
            using (var g = Graphics.FromImage(p.Image))
            {
                g.DrawImage(image, p.Width - 100, p.Height - 80);
                g.DrawString(expectedLabel.ToString(), font, Brushes.DarkBlue, p.Width - 80, p.Height - 120);

                g.DrawString(actualLabel.ToString(), font, resultBrush, p.Width - 120, p.Height - 80);
                g.DrawString($"{(int)(confidence * 100)}%", font, resultBrush, p.Width - 140, p.Height - 40);

                g.DrawString(actualLabel2.ToString(), font, resultBrush2, p.Width - 40, p.Height - 80);
                g.DrawString($"{(int)(confidence2 * 100)}%", font, resultBrush2, p.Width - 60, p.Height - 40);
            }
        }
    }
}