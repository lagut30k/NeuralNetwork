using System;
using System.Collections.Generic;
using NeuralNetwork.Engine;

namespace NeuralNetwork.UI.Providers.Settings
{
    public interface ISettingsProvider
    {
        event EventHandler LayersSettingsChanged;

        List<LayerSettings> LayersSettings { get; }

        double LearningRate { get; }

        double Moment { get; }

        double DropoutProbability { get; }

        int TrainLoops { get; }
    }
}
