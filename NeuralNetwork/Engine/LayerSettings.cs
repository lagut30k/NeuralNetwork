using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Engine
{
    public class LayerSettings
    {
        public int NeuronsCount { get; set; }

        public bool HasBias { get; set; }

        public void Deconstruct(out int neuronsCount, out bool hasBias)
        {
            neuronsCount = NeuronsCount;
            hasBias = HasBias;
        }
    }
}
