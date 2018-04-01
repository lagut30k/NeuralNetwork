using System;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine.Neurons
{
    public class OutputNeuron : Neuron
    {
        public OutputNeuron(Layer layer, int index) : base(layer, index)
        {
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
