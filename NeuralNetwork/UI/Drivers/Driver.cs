using System;
using System.Collections.Generic;
using NeuralNetwork.Engine;
using NeuralNetwork.UI.Providers;
using NeuralNetwork.UI.Providers.Data;
using NeuralNetwork.UI.Providers.Settings;

namespace NeuralNetwork.UI.Drivers
{
    public class Driver
    {
        private readonly ISettingsProvider settingsProvider;
        private readonly Func<IDataProvider> getDataProvider;
        private bool stopFlag;

        public event EventHandler ReadyToRun;

        public Driver(ISettingsProvider settingsProvider, Func<IDataProvider> getDataProvider)
        {
            this.settingsProvider = settingsProvider;
            this.getDataProvider = getDataProvider;
            settingsProvider.LayersSettingsChanged += (sender, args) => ResetNetwork();
            ResetNetwork();
        }

        public void ResetNetwork()
        {
            var settings = new NetworkSettings
            {
                LearningRate = settingsProvider.LearningRate,
                Moment = settingsProvider.Moment,
                LayersSettings = settingsProvider.LayersSettings
            };
            Network = new Network(settings);
        }

        public Network Network { get; private set; }


        private void UpdateNetworkHyperParameters()
        {
            Network.Moment = settingsProvider.Moment;
            Network.LearningRate = settingsProvider.LearningRate;
            Network.DropoutProbability = settingsProvider.DropoutProbability;
        }

        public void Train()
        {
            stopFlag = false;
            var dataProvider = getDataProvider();
            var trainLoops = settingsProvider.TrainLoops;
            UpdateNetworkHyperParameters();
            for (var i = 0; i < trainLoops && !stopFlag; i++)
            {
                var data = dataProvider.GetTrainData();
                Network.Train(data.Input, data.Output);
                if (i % 1000 == 0)
                {
                    ReadyToRun?.Invoke(this, null);
                }
            }
        }

        public void Stop()
        {
            stopFlag = true;
        }
    }
}
