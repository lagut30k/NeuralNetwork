using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.Engine.Layers
{
    public class OutputLayer : Layer
    {
        public OutputLayer(int thisLayerSize, Layer prevLayer)
        {
            PreviousLayer = prevLayer;
            Neurons = Enumerable.Range(0, thisLayerSize)
                .Select(i => new OutputNeuron(this, i) as Neuron)
                .ToList();
        }

        public override void Run()
        {
            Parallel.ForEach(Neurons, neuron1 =>
            {
                neuron1.CalcValue();
            });
        }

        public override void CalcDelta()
        {
            throw new NotImplementedException();
        }

        public List<double> GetResult()
        {
            return Neurons.Select(x => x.Value).ToList();
        }

        public void InitDelta(List<double> idealOutput)
        {
            foreach (var (neuron, output) in Neurons.Cast<OutputNeuron>().Zip(idealOutput, (neuron, output) => (neuron, output)))
            {
                neuron.InitDelta(output);
            }
        }
    }
}
