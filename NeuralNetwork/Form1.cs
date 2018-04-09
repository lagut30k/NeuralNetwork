using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.Data;
using NeuralNetwork.Engine;
using NeuralNetwork.UI;
using NeuralNetwork.UI.Drivers;
using NeuralNetwork.UI.Providers.Data;
using NeuralNetwork.UI.Providers.Settings;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        private Network Network => Driver.Network;

        private Driver Driver { get; }

        private ISettingsProvider SettingsProvider { get; }

        private IDataProvider DataProvider { get; set; }

        private IDataProvider GetDataProvider() => DataProvider;

        public Form1()
        {
            InitializeComponent();
            SettingsProvider = new SettingsProvider(
                trainLoopsTextBox,
                learningRateTextBox,
                dropoutTextBox,
                layerDataGridView
                );

            Driver = new Driver(SettingsProvider, GetDataProvider);
            DataProvider = new LogicalOperationDataProvider(driverComboBox);

            Driver.ReadyToRun += (sender, args) => Test();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            learningRateTextBox.Text = 0.7.ToString(CultureInfo.CurrentCulture);
            trainLoopsTextBox.Text = 10000.ToString(CultureInfo.CurrentCulture);
            dropoutTextBox.Text = 0.1.ToString(CultureInfo.CurrentCulture);

            Test();
            MnistLoader.LoadData(pictureBox1);
        }

        private void Test()
        {
            var inputList = new List<NetworkData>
            {
                DataProvider.GetTestData(),
                DataProvider.GetTestData(),
                DataProvider.GetTestData(),
                DataProvider.GetTestData(),
            };
            var pictureBoxes = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            if (updateTreeCheckBox.Checked)
            {
                NetworkHelper.ToTreeView(treeView1, Network);
            }
            foreach (var (input, box) in inputList.Zip(pictureBoxes, (data, box) => (data.Input, box)))
            {
                Network.Run(input);
                RedrawPictureBox(box);
            }
        }

        private void RedrawPictureBox(PictureBox pictureBox) => NetworkHelper.ToPictureBox(pictureBox, Network, pictureBox.Width / 2, 10);

        private void DisableControls()
        {
            TestButton.Enabled = false;
            TrainButton.Enabled = false;
            ResetButton.Enabled = false;
            driverComboBox.Enabled = false;
            layerDataGridView.Enabled = false;
        }

        private void EnableControls()
        {
            TestButton.Enabled = true;
            TrainButton.Enabled = true;
            ResetButton.Enabled = true;
            driverComboBox.Enabled = true;
            layerDataGridView.Enabled = true;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            Test();
            EnableControls();
        }

        private async void TrainButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            var watch = Stopwatch.StartNew();

            await Task.Run(() => Driver.Train());
            Test();

            watch.Stop();
            elapsedLabel.Text = watch.ElapsedMilliseconds.ToString();
            EnableControls();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DisableControls();
            Driver.ResetNetwork();
            Test();
            EnableControls();
        }

        private void StopButton_Click(object sender, EventArgs e) => Driver.Stop();
    }
}
