using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.WebApp.Model
{
    public class StatsSummary
    {
        public List<StatisticsEntry> StatisticsEntries { get; set; } = new List<StatisticsEntry>();
    }
}
