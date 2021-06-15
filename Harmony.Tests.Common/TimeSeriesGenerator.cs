using Harmony.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harmony.Tests.Common
{
    public abstract class TimeSeriesGenerator
    {
        public abstract double? GenerateBaselineValue(DateTime time);

        public IEnumerable<Func<double?,double?>> Modifiers { get; set; }

        public virtual IEnumerable<DataPoint> GenerateDataPoints(DateTime startDate, DateTime endDate, TimeSpan interval)
        {
            var currentTime = startDate;

            while (currentTime <= endDate)
            {
                var result = GenerateBaselineValue(currentTime);
                foreach (var modifier in Modifiers)
                {
                    result = modifier(result);
                }

                yield return new DataPoint { Timestamp = currentTime, Value = result };

                currentTime += interval;

            }
        }
    }
}
