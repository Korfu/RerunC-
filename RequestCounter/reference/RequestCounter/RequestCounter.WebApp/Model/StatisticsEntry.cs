using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.WebApp.Model
{
    public class StatisticsEntry
    {
        public string Method { get; set; }

        public int ExecutionCount { get; set; }
    }
}
