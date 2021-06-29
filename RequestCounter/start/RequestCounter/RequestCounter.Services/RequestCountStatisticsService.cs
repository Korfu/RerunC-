using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.Services
{
    /// <summary>
    /// Use this class to implement IRequestCountStatsService
    /// </summary>
    public class RequestCountStatisticsService : IRequestCountStatsService
    {     
        //List of methods which are allowed to be counted by designed service
        private static readonly string[] AllowedMethods = new string[] { "GET", "POST", "DELETE", "PATCH", "PUT" };
        private static Dictionary<string, int> _requestCount = new Dictionary<string, int>();

        // public Dictionary<string, int> RequestCount
        // {
        //     get => _requestCount;
        //     set => _requestCount = value;
        // }

        public void IncreaseCounter(string method)
        {
            if (!AllowedMethods.Contains(method))
            {
                return;
            }
            
            _requestCount.TryGetValue(method, out var currentCount); 
            _requestCount[method] = currentCount + 1;
            
            
            // if (_requestCount.Keys.Contains(method))
            // {
            //     _requestCount[method] += 1;
            // }
            // else
            // {
            //     _requestCount[method] = 1;
            // }
        }

        public Stats GetStatistics()
        {
            return new Stats(){ Counts = _requestCount};
        }
    }
}
