using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Data;

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

        public List<List<double>> TestOutputs =
            Mnist.TestLabels.Select(x => Enumerable.Range(0, 10).Select(y => y == x ? 1D : 0D).ToList()).ToList();

        public List<List<double>> TestInputs = Mnist.TestImages.Select(x => x.ToDoubles()).ToList();

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
    }
}
