using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NeuralNetwork.Engine;
using NeuralNetwork.UI.Options;

namespace NeuralNetwork.UI.Drivers
{
    public class Driver
    {
        private readonly TextBox learningRateTextBox;
        private readonly TextBox trainLoopsTextBox;
        private readonly TextBox dropoutTextBox;
        private readonly TrainData trainData;
        private readonly LayersData layersData;

        public event EventHandler ReadyToRun;

        public Driver(HyperParameters networkHyperParameters, TextBox dropoutTextBox)
        {
            this.dropoutTextBox = dropoutTextBox;
            Network = new Network(networkHyperParameters);
        }

        public Driver(TextBox learningRateTextBox, TextBox trainLoopsTextBox, TextBox dropoutTextBox, TrainData trainData, LayersData layersData)
        {
            this.learningRateTextBox = learningRateTextBox;
            this.trainLoopsTextBox = trainLoopsTextBox;
            this.trainData = trainData;
            this.layersData = layersData;
            this.dropoutTextBox = dropoutTextBox;

            ResetNetwork();
        }

        public void ResetNetwork()
        {
            Network = new Network(GetHyperParameters());
        }

        private void UpdateNetworkHyperParameters()
        {
            var parameters = GetHyperParameters();
            Moment = parameters.Moment;
            LearningRate = parameters.LearningRate;
            Network.DropoutProbability = double.TryParse(dropoutTextBox.Text, out var lr) ? lr : 0;
        }

        private HyperParameters GetHyperParameters()
        {
            return new HyperParameters
            {
                LearningRate = double.TryParse(learningRateTextBox.Text, out var lr) ? lr : 0.07,
                Moment = 1,
                LayersHyperParameters = layersData.Data
            };
        }

        public Network Network { get; private set; }

        public double Moment
        {
            get => Network.Moment;
            set => Network.Moment = value;
        }

        public double LearningRate
        {
            get => Network.LearningRate;
            set => Network.LearningRate = value;
        }

        public List<(List<double>, List<double>)> TrainData { get; set; }

        public void Train()
        {
            var trainLoops = int.TryParse(trainLoopsTextBox.Text, out var tr) ? tr : 100000;
            var data = trainData.ToNetworkFormat();
            UpdateNetworkHyperParameters();
            for (int i = 0; i < trainLoops; i++)
            {
                foreach (var (input, output) in data)
                {
                    Network.Train(input, output);
                }
                if (i % 100 == 0)
                {
                    ReadyToRun?.Invoke(this, null);
                }
            }
        }
    }
}
