using System;
using NeuralNetwork.UI.Drivers;

namespace NeuralNetwork.UI
{
    public class DriverComboBoxDto
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Func<double, double, int, Driver> DriverFactory { get; set; }
    }
}
