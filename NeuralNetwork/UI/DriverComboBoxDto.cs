using System;

namespace NeuralNetwork.UI
{
    public class DriverComboBoxDto
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Func<bool, bool, bool> TrainDataFunc { get; set; }
    }
}
