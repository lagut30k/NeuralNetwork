using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.Engine.Layers
{
    public class HiddenLayer : Layer
    {
        public HiddenLayer(LayerHyperParameters layerHyperParameters, Network network, Layer prevLayer) 
            : base(layerHyperParameters, network, prevLayer)
        {
        }

        protected override Neuron NeuronFactory(int i) => new HiddenNeuron(this, i);
    }
}
