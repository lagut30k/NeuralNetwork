using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Engine
{
    public class NetworkSettings
    {
        public double LearningRate { get; set; }

        public double Moment { get; set; }

        public List<LayerSettings> LayersSettings {get; set; }
    }
}
