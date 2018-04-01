﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine
{
    public class Network
    {
        public List<Layer> Layers { get; set; }

        public double LearningRate { get; set; }

        private OutputLayer OutputLayer => (OutputLayer) Layers.Last();

        private InputLayer InputLayer => (InputLayer) Layers.First();

        public double Moment { get; set; }

        public static Random R = new Random((int)DateTime.Now.Ticks);

        public Network(double learningRate, double moment, List<LayerHyperParameters> layersHyperParameters)
        {
            if (layersHyperParameters.Count < 2) return;

            LearningRate = learningRate;
            Moment = moment;
            var inputLayer = new InputLayer(layersHyperParameters.First(), this);
            Layers = new List<Layer>(layersHyperParameters.Count) { inputLayer };
            foreach (var layer in layersHyperParameters.Skip(1).Take(layersHyperParameters.Count - 2))
            {
                var prev = Layers.Last();
                Layers.Add(new HiddenLayer(layer, this, prev));
                prev.NextLayer = Layers.Last();
            }
            var outputLayer = new OutputLayer(layersHyperParameters.Last(), this, Layers.Last());
            Layers.Last().NextLayer = outputLayer;
            Layers.Add(outputLayer);
        }

        public Network(HyperParameters hyperParameters) 
            : this(
                hyperParameters.LearningRate, 
                hyperParameters.Moment,
                hyperParameters.LayersHyperParameters)
        {
        }

        public static double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

        public static double Grad(double value) => value * (1 - value);

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

        public bool Train(List<double> input, List<double> idealOutput)
        {
            if ((input.Count != Layers.First().Size) || (idealOutput.Count != Layers.Last().Size)) return false;

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
            return true;
        }
    }
}
