using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.Engine;
using NeuralNetwork.UI;
using NeuralNetwork.UI.Drivers;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        Network nn => Driver.Network;

        private Driver Driver { get; set; }

        //private readonly Driver Driver = new XorOneOutputDriver();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += (o, args) => RunWith();
            textBox2.TextChanged += (o, args) => RunWith();

            learningRateTextBox.Text = 0.07.ToString(CultureInfo.CurrentCulture);
            trainLoopsTextBox.Text = 10000.ToString(CultureInfo.CurrentCulture);

            driverComboBox.DataSource = new[]
            {
                new DriverComboBoxDto {ID = 1, Text = "XOR One", DriverFactory = Driver.Init<XorOneOutputDriver>},
                new DriverComboBoxDto {ID = 2, Text = "XOR Two", DriverFactory = Driver.Init<XorTwoOutputDriver>},
                new DriverComboBoxDto {ID = 3, Text = "AND One", DriverFactory = Driver.Init<AndOneOutputDriver>},
                new DriverComboBoxDto {ID = 4, Text = "AND Two", DriverFactory = Driver.Init<AndTwoOutputDriver>},
            };
            driverComboBox.DisplayMember = "Text";
            driverComboBox.SelectedValueChanged += (o, args) => ApplyDriver();
            ApplyDriver();
            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
            RunWith();
        }

        private void RunWith()
        {
            var left = double.TryParse(textBox1.Text, out var res) ? res : 0;
            var right = double.TryParse(textBox2.Text, out res) ? res : 0;

            nn.Run(new List<double> { left, right });

            NetworkHelper.ToTreeView(treeView1, nn);
            NetworkHelper.ToPictureBox(pictureBox1, nn, 400, 100);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            RunWith();
        }

        private async void TrainButton_Click(object sender, EventArgs e)
        {
            Train.Enabled = false;

            var watch = Stopwatch.StartNew();
            await Task.Run(() => Driver.Train());
            RunWith();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            elapsedLabel.Text = elapsedMs.ToString();

            Train.Enabled = true;
        }

        private void ApplyDriver()
        {
            var learingRate = double.TryParse(learningRateTextBox.Text, out var lr) ? lr : 0.07;
            var trainLoops = int.TryParse(trainLoopsTextBox.Text, out var tr) ? tr : 100000;
            double moment = 1;
            Driver = ((DriverComboBoxDto) driverComboBox.SelectedValue).DriverFactory(learingRate, moment, trainLoops);
            RunWith();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ApplyDriver();
        }

        private void driverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
