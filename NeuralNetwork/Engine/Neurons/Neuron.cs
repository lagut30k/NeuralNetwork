using System.Collections.Generic;
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

        public int WeightsCount => Weights.Count;

        protected Neuron(Layer layer, int index)
        {
            this.index = index;
            Layer = layer;
        }

        public virtual void CalcValue()
        {
            var prevLayerValues = Layer.PreviousLayer.Neurons.Select(n => n.Value);
            var totalInput = Weights.Zip(prevLayerValues, (w, input) => w * input).Sum() + Bias;
            Value = Network.Sigmoid(totalInput);
        }

        public abstract void CalcDelta();

        public void UpdateWeights()
        {
            Bias += Network.LearningRate * Delta;
            for (int k = 0; k < Weights.Count; k++)
                Weights[k] += Layer.PreviousLayer.Neurons[k].Value * Network.LearningRate * Delta;
        }
    }
}
