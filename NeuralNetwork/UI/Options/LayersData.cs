using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NeuralNetwork.Engine;

namespace NeuralNetwork.UI.Options
{
    public class LayersData
    {
        private readonly DataGridView layerDataGridView;

        public List<LayerHyperParameters> Data { get; } = new List<LayerHyperParameters>
        {
            new LayerHyperParameters {NeuronsCount = 2, HasBias = false},
            new LayerHyperParameters {NeuronsCount = 2, HasBias = true},
            new LayerHyperParameters {NeuronsCount = 1, HasBias = true},
        };

        public LayersData(DataGridView layerDataGridView)
        {
            this.layerDataGridView = layerDataGridView;
            layerDataGridView.DataSource = new BindingList<LayerHyperParameters>(Data);
        }
    }
}
