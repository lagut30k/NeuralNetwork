using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NeuralNetwork.Engine;

namespace NeuralNetwork.UI.Options
{
    public class TrainData
    {
        private readonly DataGridView trainDataGridView;
        private readonly ComboBox driverComboBox;
        private readonly LayersData layersData;

        public TrainData(DataGridView trainDataGridView, ComboBox driverComboBox, LayersData layersData)
        {
            this.trainDataGridView = trainDataGridView;
            this.driverComboBox = driverComboBox;
            this.layersData = layersData;
            trainDataGridView.AllowUserToAddRows = false;
            trainDataGridView.AllowUserToDeleteRows = false;
            trainDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            trainDataGridView.ReadOnly = false;
            InitFromDriverComboBox();
            driverComboBox.SelectedValueChanged += (sender, args) => InitFromDriverComboBox();
        }

        public List<TrainDataItemDto> Data { get; set; }

        public void InitTrainDataGridView()
        {
            var trainDataFunc = ((DriverComboBoxDto)driverComboBox.SelectedItem).TrainDataFunc;
            Data = TrainDataItemDto.CreateTrainData(trainDataFunc);
            trainDataGridView.DataSource = new BindingList<TrainDataItemDto>(Data);
        }

        private void InitFromDriverComboBox()
        {
            var trainDataFunc = ((DriverComboBoxDto)driverComboBox.SelectedItem).TrainDataFunc;
            Data = TrainDataItemDto.CreateTrainData(trainDataFunc);
            trainDataGridView.DataSource = new BindingList<TrainDataItemDto>(Data);
        }

        public List<(List<double> input, List<double> output)> ToNetworkFormat()
        {
            return Data.Select(x =>
            {
                var input = new List<double>
                {
                    Convert.ToDouble(x.InputLeft),
                    Convert.ToDouble(x.InputRight)
                };

                var outputLayerNeurons = layersData.Data.Last().NeuronsCount;

                var output = Enumerable.Repeat(0D, layersData.Data.Last().NeuronsCount).ToList();
                if (outputLayerNeurons == 0) return (input, output);
                if (outputLayerNeurons == 1)
                {
                    output[0] = Convert.ToDouble(x.Output);
                }
                else
                {
                    output[0] = Convert.ToDouble(!x.Output);
                    output[1] = Convert.ToDouble(x.Output);
                }
                return (input, output);
            }).ToList();
        }
    }
}
