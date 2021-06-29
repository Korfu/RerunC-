using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.Services
{
    public interface IRequestCountStatsService
    {
        // Dictionary<string, int> RequestCount { get; set; }
        
        /// <summary>
        /// Increase request counter for given as param http method
        /// </summary>
        /// <param name="method"></param>
        void IncreaseCounter(string method);

        /// <summary>
        /// Get total statistics of executed methods and their execution number
        /// </summary>
        /// <returns></returns>
        Stats GetStatistics();
    }
}
