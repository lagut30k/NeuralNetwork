using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Data;
using NeuralNetwork.UI.Drawers;

namespace NeuralNetwork.UI.Providers.Data
{
    public class MnistDataProvider : IDataProvider
    {
        private static readonly Random R = new Random();

        public int InputNeuronsCount { get; } = 28 * 28;

        public int OutputNeuronsCount { get; } = 10;

        public List<List<double>> TrainInputs = Mnist.TrainImages.Select(x => x.ToDoubles()).ToList();

        public List<List<double>> TrainOutputs =
            Mnist.TrainLabels.Select(x => Enumerable.Range(0, 10).Select(y => y == x ? 1D : 0D).ToList()).ToList();

        public List<List<double>> TestInputs = Mnist.TestImages.Select(x => x.ToDoubles()).ToList();

        public List<List<double>> TestOutputs =
            Mnist.TestLabels.Select(x => Enumerable.Range(0, 10).Select(y => y == x ? 1D : 0D).ToList()).ToList();

        public NetworkData GetTrainData()
        {
            var index = R.Next(TrainInputs.Count);
            return new NetworkData(TrainInputs[index], TrainOutputs[index]);
        }

        public NetworkData GetTestData()
        {
            var index = R.Next(TestInputs.Count);
            return new NetworkData(TestInputs[index], TestOutputs[index]);
        }

        public IEnumerable<NetworkData> GetAllTestData() => TestInputs.Zip(TestOutputs, (i, o) => new NetworkData(i,o));

        public bool ValidateResult(List<double> expected, List<double> actual)
        {
            return ListToLabel(expected) == ListToLabel(actual);
        }

        public double Mse(List<double> expected, List<double> actual)
        {
            return expected.Zip(actual, (e, a) => e - a).Sum(x => x * x) / expected.Count;
        }

        public double CrossEntropy(List<double> expected, List<double> actual)
        {
            return expected.Zip(actual, (e, a) => -e * Math.Log(a + 1e-12)).Sum() / expected.Count;
        }

        public IDrawer ResultDrawingFactory(List<double> input, List<double> expected, List<double> actual) => new MnistDrawer(input, expected, actual);

        private static int ListToLabel(List<double> list)
        {
            var m = list.Max();
            return list.IndexOf(m);
        }
    }
}
