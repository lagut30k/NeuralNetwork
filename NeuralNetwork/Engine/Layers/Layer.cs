using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.Engine.Layers
{
    public abstract class Layer
    {
        private Layer nextLayer;

        public List<Neuron> Neurons { get; set; }
        
        public bool HasBias { get; }
        
        public int Size => Neurons.Count;

        public Layer PreviousLayer { get; }

        public Layer NextLayer
        {
            get => nextLayer;
            set
            {
                nextLayer = value;
                InitNeuronsWeights();
            }
        }

        public Network Network { get; }

        protected abstract Neuron NeuronFactory(int i);

        protected void InitNeuronsWeights()
        {
            foreach (var neuron in Neurons)
            {
                neuron.InitWeights();
            }
        }

        protected Layer(LayerHyperParameters layerHyperParameters, Network network, Layer previousLayer = null)
        {
            Network = network;
            HasBias = layerHyperParameters.HasBias;
            PreviousLayer = previousLayer;
            Neurons = Enumerable.Range(0, layerHyperParameters.NeuronsCount)
                .Select(NeuronFactory)
                .ToList();

            if (previousLayer != null)
            {
                PreviousLayer.NextLayer = this;
            }
        }

        public virtual void Run()
        {
            Parallel.ForEach(Neurons, neuron =>
            {
                neuron.CalcValue();
            });
            //foreach (var neuron in Neurons)
            //{
            //    neuron.CalcValue();
            //}
        }

        public virtual void CalcDelta()
        {
            Parallel.ForEach(Neurons, neuron =>
            {
                neuron.CalcDelta();
            });
            //foreach (var neuron in Neurons)
            //{
            //    neuron.CalcDelta();
            //}
        }

        public void UpdateWeights()
        {
            foreach (var neuron in Neurons)
            {
                neuron.UpdateWeights();
            }
        }
    }
}
