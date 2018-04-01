using System;
using System.Collections.Generic;
using NeuralNetwork.Engine;

namespace NeuralNetwork.UI.Drivers
{
    public abstract class Driver
    {
        protected Driver(double learingRate, double moment, int trainLoops)
        {
            TrainLoops = trainLoops;
            Network = new Network(learingRate, moment, Layers);
        }

        protected abstract int[] Layers { get; }

        public static Driver Init<T>(double learingRate, double moment, int trainLoops) where T : Driver
        {
            return (Driver)Activator.CreateInstance(typeof(T), learingRate, moment, trainLoops);
        }

        public virtual Network Network { get; }

        private int TrainLoops { get; }

        public abstract void TrainInternal();

        public virtual void Train()
        {
            for (int i = 0; i < TrainLoops; i++)
            {
                TrainInternal();
            }
        }
    }

    class XorTwoOutputDriver : Driver
    {
        public XorTwoOutputDriver(double learingRate, double moment, int trainLoops) : base(learingRate, moment, trainLoops)
        { }

        protected override int[] Layers { get; } = { 2, 2, 2 };

        public override void TrainInternal()
        {
            Network.Train(new List<double> { 0, 0 }, new List<double> { 1, 0 });
            Network.Train(new List<double> { 0, 1 }, new List<double> { 0, 1 });
            Network.Train(new List<double> { 1, 0 }, new List<double> { 0, 1 });
            Network.Train(new List<double> { 1.5, 1.5 }, new List<double> { 1, 0 });
        }
    }

    class XorOneOutputDriver : Driver
    {
        public XorOneOutputDriver(double learingRate, double moment, int trainLoops) : base(learingRate, moment, trainLoops)
        { }

        protected override int[] Layers { get; } = { 2, 2, 1 };

        public override void TrainInternal()
        {
            Network.Train(new List<double> { 0, 0 }, new List<double> { 0 });
            Network.Train(new List<double> { 0, 1 }, new List<double> { 1 });
            Network.Train(new List<double> { 1, 0 }, new List<double> { 1 });
            Network.Train(new List<double> { 1, 1 }, new List<double> { 0 });
        }
    }

    class AndOneOutputDriver : Driver
    {
        public AndOneOutputDriver(double learingRate, double moment, int trainLoops) : base(learingRate, moment, trainLoops)
        { }

        protected override int[] Layers { get; } = { 2, 2, 1 };

        public override void TrainInternal()
        {
            Network.Train(new List<double> { 0, 0 }, new List<double> { 0 });
            Network.Train(new List<double> { 0, 1 }, new List<double> { 0 });
            Network.Train(new List<double> { 1, 0 }, new List<double> { 0 });
            Network.Train(new List<double> { 1, 1 }, new List<double> { 1 });
        }
    }

    class AndTwoOutputDriver : Driver
    {
        public AndTwoOutputDriver(double learingRate, double moment, int trainLoops) : base(learingRate, moment, trainLoops)
        { }

        protected override int[] Layers { get; } = { 2, 2, 2 };

        public override void TrainInternal()
        {
            Network.Train(new List<double> { 0, 0 }, new List<double> { 1, 0 });
            Network.Train(new List<double> { 0, 1 }, new List<double> { 1, 0 });
            Network.Train(new List<double> { 1, 0 }, new List<double> { 1, 0 });
            Network.Train(new List<double> { 1, 1 }, new List<double> { 0, 1 });
        }
    }
}
