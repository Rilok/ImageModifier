using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class Benchmark
    {
        private static DateTime start = DateTime.MinValue;
        private static DateTime end = DateTime.MinValue;

        private static TimeSpan Span
        {
            get
            {
                return end.Subtract(start);
            }
        }

        public static void Start()
        {
            start = DateTime.Now;
        }

        public static void End()
        {
            end = DateTime.Now;
        }

        public static double GetSeconds()
        {
            if (end == DateTime.MinValue)
                return 0.0;
            else
                return Span.TotalSeconds;
        }
    }
}
