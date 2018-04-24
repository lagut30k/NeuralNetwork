using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NeuralNetwork.UI.Drawers;

namespace NeuralNetwork.UI.Providers.Data
{
    public class LogicalOperationDataProvider : IDataProvider
    {
        private static readonly Random R = new Random();
        private readonly LogicalOperatorComboBoxItem[] generatorOptions =
            {
                new LogicalOperatorComboBoxItem {Text = "XOR", Generator = (a, b) => a ^ b},
                new LogicalOperatorComboBoxItem {Text = "AND", Generator = (a, b) => a && b},
                new LogicalOperatorComboBoxItem {Text = "OR", Generator = (a, b) => a || b},
                new LogicalOperatorComboBoxItem {Text = "=>", Generator = (a, b) => !a || b},
                new LogicalOperatorComboBoxItem {Text = "<=", Generator = (a, b) => a || !b},
                new LogicalOperatorComboBoxItem {Text = "<=>", Generator = (a, b) => a == b},
            };

        private Func<bool, bool, bool> generator;
        private int internalVal;



        public LogicalOperationDataProvider(ComboBox driverComboBox)
        {
            driverComboBox.DataSource = generatorOptions;
            driverComboBox.DisplayMember = "Text";
            driverComboBox.SelectedValueChanged += (sender, args) =>
                generator = ((LogicalOperatorComboBoxItem)driverComboBox.SelectedItem).Generator;
            generator = ((LogicalOperatorComboBoxItem)driverComboBox.SelectedItem).Generator;
        }

        public int InputNeuronsCount { get; } = 2;

        public int OutputNeuronsCount { get; } = 2;

        public NetworkData GetTrainData() => IntToNetworkData(R.Next(4));

        public NetworkData GetTestData() => IntToNetworkData(internalVal++);

        public IEnumerable<NetworkData> GetAllTestData()
        {
            return new[] {0, 1, 2, 3}.Select(IntToNetworkData);
        }

        public bool ValidateResult(List<double> expected, List<double> actual)
        {
            return ListToLabel(expected) == ListToLabel(actual);
        }
        public double Mse(List<double> expected, List<double> actual)
        {
            return expected.Zip(actual, (e, a) => e - a).Sum(x => x * x) / expected.Count;
        }

        public double CrossEntropy(List<double> expected, List<double> actual)
        {
            return expected.Zip(actual, (e, a) => e * Math.Log(a + 1e-12)).Sum(x => -x) / expected.Count;
        }

        private NetworkData IntToNetworkData(int i)
        {
            var left = Convert.ToBoolean(i & 2);
            var right = Convert.ToBoolean(i & 1);
            var result = generator(left, right);
            var input = new List<double>
            {
                Convert.ToDouble(left),
                Convert.ToDouble(right)
            };
            var output = new List<double>()
            {
                Convert.ToDouble(!result),
                Convert.ToDouble(result)
            };
            return new NetworkData(input, output);
        }

        public IDrawer ResultDrawingFactory(List<double> input, List<double> expected, List<double> actual) => new LogicalDrawer(input, expected, actual);

        private static int ListToLabel(List<double> list)
        {
            var m = list.Max();
            return list.IndexOf(m);
        }
    }
}
