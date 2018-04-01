using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Engine
{
    public class HyperParameters
    {
        public double LearningRate { get; set; }

        public double Moment { get; set; }

        public List<LayerHyperParameters> LayersHyperParameters {get; set; }
    }
}
