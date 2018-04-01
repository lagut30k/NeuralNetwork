using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.Engine.Layers
{
    public class InputLayer : Layer
    {
        public InputLayer(int thisLayerSize)
        {
            Neurons = Enumerable.Range(0, thisLayerSize)
                .Select(i => new InputNeuron(this, i) as Neuron)
                .ToList();
        }

        public void AssignInput(List<double> input)
        {
            Neurons.Zip(input, (neuron, d) => neuron.Value = d).ToList();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void CalcDelta()
        {
            foreach (var neuron in Neurons)
            {
                neuron.CalcDelta();
            }
        }
    }
}