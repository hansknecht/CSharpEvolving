using System;
using System.Threading;

namespace Packt.Shared
{
    public static class Squarer
    {
        public static Double Square<T>(T input) where T : IConvertible
        {
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);

            return d * d;
        }
    }
}