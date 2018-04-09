using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine
{
    public class Network
    {
        private OutputLayer OutputLayer => (OutputLayer) Layers.Last();

        private InputLayer InputLayer => (InputLayer) Layers.First();

        public List<Layer> Layers { get; set; }

        public double LearningRate { get; set; }

        public double DropoutProbability { get; set; } = 0.3D;

        public double Moment { get; set; }

        public static Random R = new Random((int)DateTime.Now.Ticks);

        public static double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

        public static double Grad(double value) => value * (1 - value);

        public static double GetInitWeight(int inputNeurons, int outputNeurons) => UniformRandom(2D / (inputNeurons + outputNeurons));

        private static double UniformRandom(double variance) => (R.NextDouble() - 0.5) * Math.Sqrt(12 * variance);

        private static double GaussRandom(double variance) => Enumerable.Repeat(0, 12).Sum(_ => R.NextDouble() - 0.5) * Math.Sqrt(variance);

        private Network(double learningRate, double moment, List<LayerSettings> layersHyperParameters)
        {
            if (layersHyperParameters.Count < 2) return;

            LearningRate = learningRate;
            Moment = moment;
            var inputLayer = new InputLayer(layersHyperParameters.First(), this);
            Layers = new List<Layer>(layersHyperParameters.Count) { inputLayer };
            foreach (var layerParams in layersHyperParameters.Skip(1).Take(layersHyperParameters.Count - 2))
            {
                var prev = Layers.Last();
                Layers.Add(new HiddenLayer(layerParams, this, prev));
            }
            Layers.Add(new OutputLayer(layersHyperParameters.Last(), this, Layers.Last()));
        }

        public Network(NetworkSettings networkSettings) 
            : this(
                networkSettings.LearningRate, 
                networkSettings.Moment,
                networkSettings.LayersSettings)
        {
        }

        public List<double> Run(List<double> input)
        {
            if (input.Count != Layers[0].Size) return null;

            InputLayer.AssignInput(input);
            foreach (var layer in Layers.Skip(1))
            {
                layer.Run();
            }
            return OutputLayer.GetResult();
        }

        private void Dropout()
        {
            foreach (var hiddenLayer in Layers.OfType<HiddenLayer>())
            {
                hiddenLayer.Dropout();
            }
        }

        private void ClearDropout()
        {
            foreach (var hiddenLayer in Layers.OfType<HiddenLayer>())
            {
                hiddenLayer.ClearDropout();
            }
        }

        public bool Train(List<double> input, List<double> idealOutput)
        {
            if ((input.Count != Layers.First().Size) || (idealOutput.Count != Layers.Last().Size)) return false;

            Dropout();

            Run(input);

            OutputLayer.InitDelta(idealOutput);
            foreach (var layer in Layers.Skip(1).Reverse().Skip(1))
            {
                layer.CalcDelta();
            }

            foreach (var layer in Layers.Skip(1))
            {
                layer.UpdateWeights();
            }

            ClearDropout();
            return true;
        }
    }
}
