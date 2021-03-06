﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NeuralNetwork.Engine;

namespace NeuralNetwork.UI.Providers.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly TextBox trainLoopsTextBox;
        private readonly TextBox learningRateTextBox;
        private readonly TextBox dropoutTextBox;

        public SettingsProvider(TextBox trainLoopsTextBox, TextBox learningRateTextBox, TextBox dropoutTextBox, DataGridView layerDataGridView)
        {
            this.trainLoopsTextBox = trainLoopsTextBox;
            this.learningRateTextBox = learningRateTextBox;
            this.dropoutTextBox = dropoutTextBox;
            layerDataGridView.DataSource = new BindingList<LayerSettings>(LayersSettings);
            layerDataGridView.CellValueChanged += (sender, args) => LayersSettingsChanged?.Invoke(this, null);
        }

        public event EventHandler LayersSettingsChanged;

        public List<LayerSettings> LayersSettings { get; } = new List<LayerSettings>
        {
            new LayerSettings {NeuronsCount = 784, HasBias = false},
            new LayerSettings {NeuronsCount = 300, HasBias = true},
            new LayerSettings {NeuronsCount = 10, HasBias = true},
        };

        public double LearningRate => double.TryParse(learningRateTextBox.Text, out var lr) ? lr : 0.07;

        public double Moment { get; } = 1;

        public double DropoutProbability => double.TryParse(dropoutTextBox.Text, out var lr) ? lr : 0;

        public int TrainLoops => int.TryParse(trainLoopsTextBox.Text, out var tr) ? tr : 10000;
    }
}
