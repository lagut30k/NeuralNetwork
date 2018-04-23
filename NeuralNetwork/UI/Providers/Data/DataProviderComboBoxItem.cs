using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.UI.Providers.Data
{
    public class DataProviderComboBoxItem
    {
        public string Text { get; set; }

        public Func<IDataProvider> Factory { get; set; }
    }
}
