using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NeuralNetwork.Engine;
using NeuralNetwork.Engine.Layers;
using NeuralNetwork.Engine.Neurons;

namespace NeuralNetwork.UI
{
    public static class NetworkHelper
    {
        public static void ToTreeView(TreeView t, Network nn)
        {
            TreeNode root;
            if (t.Nodes.Count == 1)
            {
                root = t.Nodes[0];
            }
            else
            {
                t.Nodes.Clear();
                root = new TreeNode("NeuralNetwork");
                t.Nodes.Add(root);
            }
            ApplyRoot(root, nn);
        }

        private static void ApplyRoot(TreeNode rootNode, Network network)
        {
            if (rootNode.Nodes.Count == network.Layers.Count)
            {
                var zippedLayers = rootNode.Nodes.Cast<TreeNode>().Zip(network.Layers, (layerNode, layer) => (layerNode, layer));
                foreach (var (layerNode, layer) in zippedLayers)
                {
                    ApplyLayer(layerNode, layer);
                }
            }
            else
            {
                rootNode.Nodes.Clear();
                foreach (var layer in network.Layers)
                {
                    var layerNode = new TreeNode("Layer");
                    ApplyLayer(layerNode, layer);
                    rootNode.Nodes.Add(layerNode);
                }
            }
        }

        private static void ApplyLayer(TreeNode layerNode, Layer layer)
        {
            layerNode.Text = layer.GetType().Name;
            if (layerNode.Nodes.Count == layer.Neurons.Count)
            {
                var zipped = layerNode.Nodes.Cast<TreeNode>().Zip(layer.Neurons, (neuronNode, neuron) => (neuronNode, neuron));
                foreach (var (neuronNode, neuron) in zipped)
                {
                    ApplyNeuron(neuronNode, neuron);
                }
                return;
            }
            layerNode.Nodes.Clear();
            foreach (var neuron in layer.Neurons)
            {
                var neuronNode = new TreeNode();
                ApplyNeuron(neuronNode, neuron);
                layerNode.Nodes.Add(neuronNode);
            }
        }

        private static void ApplyNeuron(TreeNode neuronNode, Neuron neuron)
        {
            neuronNode.Text = $@"Neuron: {neuron.Value}";
            if (neuronNode.Nodes.Count == neuron.Weights.Count + 2)
            {
                neuronNode.Nodes[0].Text = $@"Bias: {neuron.Bias}";
                neuronNode.Nodes[1].Text = $@"Delta: {neuron.Delta}";
                var zipped = neuronNode.Nodes.Cast<TreeNode>().Skip(2).Zip(neuron.Weights, (nodeW, w) => (nodeW, w));
                foreach (var (nodeW, w) in zipped)
                {
                    nodeW.Text = $@"Weight: {w}";
                }
                return;
            }
            neuronNode.Nodes.Clear();
            neuronNode.Nodes.Add($@"Bias: {neuron.Bias}");
            neuronNode.Nodes.Add($@"Delta: {neuron.Delta}");
            foreach (var w in neuron.Weights)
            {
                neuronNode.Nodes.Add($@"Weight: {w}");
            }
        }

        public static void ToPictureBox(PictureBox p, Network nn, int X, int Y)
        {
            int neuronWidth = 30;
            int neuronDistance = 50;
            int layerDistance = 50;
            int fontSize = 8;

            Bitmap b = new Bitmap(p.Width, p.Height);
            Graphics g = Graphics.FromImage(b);

            g.FillRectangle(Brushes.White, g.ClipBounds);

            int y = Y;

            for (int l = 0; l < nn.Layers.Count; l++)
            {
                Layer layer = nn.Layers[l];

                int x = X - (neuronDistance * (layer.Neurons.Count / 2));

                for (int n = 0; n < layer.Neurons.Count; n++)
                {
                    Neuron neuron = layer.Neurons[n];

                    //for (int d = 0; d < neuron.Dendrites.Count; d++)
                    //{
                    //    // TO DO: optionally draw dendrites between neurons 
                    //};

                    g.FillEllipse(Brushes.WhiteSmoke, x, y, neuronWidth, neuronWidth);
                    g.DrawEllipse(Pens.Gray, x, y, neuronWidth, neuronWidth);
                    g.DrawString(neuron.Value.ToString("0.00"), new Font("Arial", fontSize), Brushes.Black, x + 2, y + (neuronWidth / 2) - 5);

                    x += neuronDistance;
                }

                y += layerDistance;
            }

            p.Image = b;
        }

    }
}