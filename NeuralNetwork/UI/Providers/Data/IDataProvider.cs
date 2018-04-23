using System.Collections.Generic;
using NeuralNetwork.UI.Drawers;

namespace NeuralNetwork.UI.Providers.Data
{
    public interface IDataProvider
    {
        int InputNeuronsCount { get; }

        int OutputNeuronsCount { get; }

        NetworkData GetTrainData();

        NetworkData GetTestData();

        IDrawer ResultDrawingFactory(List<double> input, List<double> expected, List<double> actual);
    }
}
