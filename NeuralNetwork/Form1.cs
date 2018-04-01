using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.Engine;
using NeuralNetwork.UI;
using NeuralNetwork.UI.Drivers;
using NeuralNetwork.UI.Options;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        private Network Network => Driver.Network;

        private Driver Driver { get; }

        private TrainData TrainData { get; }

        private LayersData LayersData { get; }

        public Form1()
        {
            InitializeComponent();
            LayersData = new LayersData(layerDataGridView);

            driverComboBox.DataSource = new[]
            {
                new DriverComboBoxDto {ID = 1, Text = "XOR", TrainDataFunc = (a,b) => a ^ b},
                new DriverComboBoxDto {ID = 1, Text = "AND", TrainDataFunc = (a,b) => a && b},
                new DriverComboBoxDto {ID = 1, Text = "OR", TrainDataFunc = (a,b) => a || b},
            };

            driverComboBox.DisplayMember = "Text";
            TrainData = new TrainData(trainDataGridView, driverComboBox, LayersData);
            Driver = new Driver(learningRateTextBox, trainLoopsTextBox, TrainData, LayersData);
            Driver.ReadyToRun += (sender, args) => Test();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leftInputTextBox.TextChanged += (o, args) => RunForward();
            rightInputTextBox.TextChanged += (o, args) => RunForward();
            layerDataGridView.CellValueChanged += (o, args) => ResetNetworkAndRun();

            learningRateTextBox.Text = 0.07.ToString(CultureInfo.CurrentCulture);
            trainLoopsTextBox.Text = 10000.ToString(CultureInfo.CurrentCulture);

            driverComboBox.SelectedValueChanged += (o, args) => TrainData.InitTrainDataGridView(); ;

            TrainData.InitTrainDataGridView();
            Test();
        }


        private void RunForward()
        {
            var left = double.TryParse(leftInputTextBox.Text, out var res) ? res : 0;
            var right = double.TryParse(rightInputTextBox.Text, out res) ? res : 0;
            Network.Run(new List<double> { left, right });
            NetworkHelper.ToTreeView(treeView1, Network);
            RedrawPictureBox(pictureBox1);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            Test();
            RunForward();
            EnableControls();
        }

        private void ResetNetworkAndRun()
        {
            DisableControls();
            Driver.ResetNetwork();
            Test();
            RunForward();
            EnableControls();
        }

        private void Test()
        {
            var inputList = TrainData.ToNetworkFormat().Select(x => x.input).ToList();
            var pictureBoxes = new List<PictureBox>() {pictureBox1, pictureBox2, pictureBox3, pictureBox4};
            foreach (var (input, box) in inputList.Zip(pictureBoxes, (input, box) => (input, box)))
            {
                Network.Run(input);
                RedrawPictureBox(box);
            }
        }

        private void RedrawPictureBox(PictureBox pictureBox) => NetworkHelper.ToPictureBox(pictureBox, Network, pictureBox.Width / 2, 50);

        private void DisableControls()
        {
            RunButton.Enabled = false;
            TrainButton.Enabled = false;
            ResetButton.Enabled = false;
            driverComboBox.Enabled = false;
            trainDataGridView.Enabled = false;
            layerDataGridView.Enabled = false;
        }

        private void EnableControls()
        {
            RunButton.Enabled = true;
            TrainButton.Enabled = true;
            ResetButton.Enabled = true;
            driverComboBox.Enabled = true;
            trainDataGridView.Enabled = true;
            layerDataGridView.Enabled = true;
        }

        private async void TrainButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            TrainButton.Enabled = false;
            
            var watch = Stopwatch.StartNew();
            
            await Task.Run(() => Driver.Train());
            RunForward();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            elapsedLabel.Text = elapsedMs.ToString();
            EnableControls();
            TrainButton.Enabled = true;
        }
        
        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetNetworkAndRun();
        }
    }
}
