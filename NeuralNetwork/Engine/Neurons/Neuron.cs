﻿using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine.Neurons
{
    public abstract class Neuron
    {
        protected Layer Layer { get; set; }

        protected readonly int index;

        public List<double> Weights { get; set; } = new List<double>();

        public double Bias { get; set; }
        
        public double Delta { get; set; }
        
        public double Value { get; set; }

        protected Neuron(Layer layer, int index)
        {
            this.index = index;
            Layer = layer;
            Weights = Enumerable.Range(0, layer.PreviousLayer?.Size ?? 0)
                .Select(_ => Network.R.NextDouble())
                .ToList();
        }

        public virtual void CalcValue()
        {
            var prevLayerValues = Layer.PreviousLayer.Neurons.Select(n => n.Value);
            var totalInput = Weights.Zip(prevLayerValues, (w, input) => w * input).Sum() + (Layer.HasBias ? Bias : 0);
            Value = Network.Sigmoid(totalInput);
        }

        public virtual void CalcDelta()
        {
            Delta = Network.Grad(Value) * Layer.NextLayer.Neurons.Sum(x => x.Weights[index] * x.Delta);
        }

        public void UpdateWeights()
        {
            var learningRate = Layer.Network.LearningRate;
            if (Layer.HasBias)
            {
                Bias += learningRate* Delta;
            }
            for (int k = 0; k < Weights.Count; k++)
                Weights[k] += Layer.PreviousLayer.Neurons[k].Value * learningRate * Delta;
        }
    }
}
