using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.UI
{
    public class TrainDataItemDto
    {
        public bool InputLeft { get; set; }

        public bool InputRight { get; set; }

        public bool Output { get; set; }

        public static List<TrainDataItemDto> CreateTrainData(Func<bool, bool, bool> func)
        {
            return new List<TrainDataItemDto>
            {
                new TrainDataItemDto { InputLeft = false, InputRight = false, Output = func(false, false) },
                new TrainDataItemDto { InputLeft = false, InputRight = true, Output = func(false, true) },
                new TrainDataItemDto { InputLeft = true, InputRight = false, Output = func(true, false) },
                new TrainDataItemDto { InputLeft = true, InputRight = true, Output = func(true, true) },
            };
        }
    }
}
