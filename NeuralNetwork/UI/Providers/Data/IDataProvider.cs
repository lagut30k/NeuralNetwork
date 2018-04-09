namespace NeuralNetwork.UI.Providers.Data
{
    public interface IDataProvider
    {
        int InputNeuronsCount { get; }

        int OutputNeuronsCount { get; }

        NetworkData GetTrainData();

        NetworkData GetTestData();
    }
}
