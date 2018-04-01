using System;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine.Neurons
{
    public class OutputNeuron : Neuron
    {
        public OutputNeuron(Layer layer, int index) : base(layer, index)
        {
            Weights = Enumerable.Range(0, layer.PreviousLayer.Size)
                .Select(_ => Network.R.NextDouble())
                .ToList();
        }

        public override void CalcDelta()
        {
            throw new NotImplementedException();
        }

        public void InitDelta(double idealOutput)
        {
            Delta = Network.Grad(Value) * (idealOutput - Value);
        }
    }
}
