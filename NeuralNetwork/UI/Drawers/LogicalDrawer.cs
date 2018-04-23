using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NeuralNetwork.UI.Drawers
{
    public class LogicalDrawer : IDrawer
    {
        private readonly List<double> input;
        private readonly List<double> expected;
        private readonly List<double> actual;

        public LogicalDrawer(List<double> input, List<double> expected, List<double> actual)
        {
            this.input = input;
            this.expected = expected;
            this.actual = actual;
        }

        private static bool ListToLabel(List<double> list)
        {
            var m = list.Max();
            return Convert.ToBoolean(list.IndexOf(m));
        }

        public void Draw(PictureBox p)
        {
            var left = Convert.ToBoolean(input[0]);
            var right = Convert.ToBoolean(input[1]);
            var expectedLabel = ListToLabel(expected);
            var actualLabel = ListToLabel(actual);
            var confidence = actual.Max();
            var font = new Font("Arial", 20);
            var resultBrush = actualLabel == expectedLabel ? Brushes.Green : Brushes.OrangeRed;
            using (var g = Graphics.FromImage(p.Image))
            {
                //g.DrawImage(image, 0, 0);
                g.DrawString(left.ToString(), font, Brushes.Black, p.Width * 3 / 4 - 100, p.Height - 80);
                g.DrawString(right.ToString(), font, Brushes.Black, p.Width * 3 / 4 - 100, p.Height - 40);
                g.DrawString(expectedLabel.ToString(), font, Brushes.Black, p.Width - 100, p.Height - 120);
                g.DrawString(actualLabel.ToString(), font, resultBrush, p.Width - 100, p.Height - 80);
                g.DrawString($"{(int)(confidence * 100)}%", font, Brushes.Black, p.Width - 60, p.Height - 40);
            }
        }
    }
}