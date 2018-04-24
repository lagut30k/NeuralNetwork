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

            InitDataProviderComboBox();

            //DataProvider = new LogicalOperationDataProvider(driverComboBox);

            Driver.ReadyToRun += (sender, args) => Test();
            Driver.ReadyToFullTest += (sender, args) => FullTest();
        }

        private void InitDataProviderComboBox()
        {

            dataComboBox.DataSource = new[] {
                new DataProviderComboBoxItem { Text = "MNIST", Factory = () => new MnistDataProvider() },
                new DataProviderComboBoxItem { Text = "Logical", Factory = () => new LogicalOperationDataProvider(driverComboBox) }
            };
            dataComboBox.DisplayMember = "Text";
            dataComboBox.SelectedValueChanged += (sender, args) =>
            {
                DataProvider = ((DataProviderComboBoxItem)dataComboBox.SelectedItem).Factory();
                SettingsProvider.LayersSettings.First().NeuronsCount = DataProvider.InputNeuronsCount;
                SettingsProvider.LayersSettings.Last().NeuronsCount = DataProvider.OutputNeuronsCount;
                layerDataGridView.Refresh();
                //layerDataGridView.DataSource = layerDataGridView.DataSource;
            };
            DataProvider = ((DataProviderComboBoxItem)dataComboBox.SelectedItem).Factory();
            SettingsProvider.LayersSettings.First().NeuronsCount = DataProvider.InputNeuronsCount;
            SettingsProvider.LayersSettings.Last().NeuronsCount = DataProvider.OutputNeuronsCount;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            learningRateTextBox.Text = 0.7.ToString(CultureInfo.CurrentCulture);
            trainLoopsTextBox.Text = 10000.ToString(CultureInfo.CurrentCulture);
            dropoutTextBox.Text = 0.1.ToString(CultureInfo.CurrentCulture);

            Test();
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
            var i = 0;
            foreach (var (data, box) in inputList.Zip(pictureBoxes, (data, box) => (data, box)))
            {
                var actual = Network.Run(data.Input);
                RedrawPictureBox(box);
                if (actual == null)
                {
                    continue;
                }
                var drawer = DataProvider.ResultDrawingFactory(data.Input, data.Output, actual);
                drawer.Draw(box);

                //Mnist.DrawTest(box, i++);
            }
        }

        private void FullTest()
        {
            var total = 0;
            var valid = 0;
            var mse = 0D;
            var crossEntropy = 0D;
            foreach (var testData in DataProvider.GetAllTestData())
            {
                var actual = Network.Run(testData.Input);
                if (actual == null)
                {
                    return;
                }
                mse += DataProvider.Mse(testData.Output, actual);
                crossEntropy += DataProvider.CrossEntropy(testData.Output, actual);
                if (DataProvider.ValidateResult(testData.Output, actual))
                {
                    valid++;
                }
                total++;
            }
            var classificationError = ((double)total - valid) / total;
            mse /= total;
            crossEntropy /= total;

            classificationErrorLabel.Invoke(new Action(() => classificationErrorLabel.Text = $@"{classificationError * 100:F2}% / {total - valid} / {total}"));
            meanSquaredErrorLabel.Invoke(new Action(() => meanSquaredErrorLabel.Text = $@"{mse * 100:F2}%"));
            crossEntropyErrorLabel.Invoke(new Action(() => crossEntropyErrorLabel.Text = $@"{crossEntropy * 100:F2}%"));
            //testResultLabel.Text = $@"{error * 100:F1} / {total - valid} / {total}";
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

        private void dataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataProvider = new LogicalOperationDataProvider(driverComboBox);
        }
    }
}
