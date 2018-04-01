using System.Collections.Generic;
using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.Engine.Layers
{
    public abstract class Layer
    {
        public List<Neuron> Neurons { get; set; }

        public virtual Layer NextLayer { get; set; }

        public virtual Layer PreviousLayer { get; protected set; }

        public int Size => Neurons.Count;

        public abstract void Run();

        public abstract void CalcDelta();

        public void UpdateWeights()
        {
            foreach (var neuron in Neurons)
            {
                neuron.UpdateWeights();
            }
        }
    }
}
