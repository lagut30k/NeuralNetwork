using System;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine.Neurons
{
    public class HiddenNeuron : Neuron
    {
        protected static Random RandomGenerator = new Random(Environment.TickCount);

        public HiddenNeuron(Layer layer, int index) : base(layer, index)
        {
            Weights = Enumerable.Range(0, layer.PreviousLayer.Size)
                .Select(_ => Network.R.NextDouble())
                .ToList();
        }

        public override void CalcDelta()
        {
            Delta = Network.Grad(Value) * Layer.NextLayer.Neurons.Sum(x => x.Weights[index] * x.Delta);
        }
    }
}
