using System.Linq;
using System.Threading.Tasks;
using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.Engine.Layers
{
    public class HiddenLayer : Layer
    {
        public HiddenLayer(int thisLayerSize, Layer prevLayer)
        {
            PreviousLayer = prevLayer;
            Neurons = Enumerable.Range(0, thisLayerSize)
                .Select(i => new HiddenNeuron(this, i) as Neuron)
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
            foreach (var neuron in Neurons)
            {
                neuron.CalcDelta();
            }
        }
    }
}
