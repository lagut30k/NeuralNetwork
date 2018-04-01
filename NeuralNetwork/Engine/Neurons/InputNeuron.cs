using System;
using System.Linq;
using NeuralNetwork.Engine.Layers;

namespace NeuralNetwork.Engine.Neurons
{
    public class InputNeuron : Neuron
    {
        public InputNeuron(Layer layer, int index) : base(layer, index)
        {
        }

        public override void CalcValue()
        {
            throw new NotImplementedException();
        }

        public override void CalcDelta()
        {
            throw new NotImplementedException();
            //Delta = Network.Grad(Value) * Layer.NextLayer.Neurons.Sum(x => x.Weights[index] * x.Delta);
        }
    }
}
