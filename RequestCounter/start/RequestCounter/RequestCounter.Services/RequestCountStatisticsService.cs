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
        private static readonly string[] AllowedMethods = new string[] {"GET", "POST", "DELETE", "PATCH", "PUT"};
        private static Dictionary<string, int> _requestCount;
        private readonly object objectLock = new object();

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

            lock (objectLock)
            {
                _requestCount = DataReader.ReadFromFile();

                _requestCount.TryGetValue(method, out var currentCount);
                _requestCount[method] = currentCount + 1;

                DataReader.WriteToFile(_requestCount);
            }


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
            {
                lock (objectLock)
                {
                    _requestCount = DataReader.ReadFromFile();
                }

                return new Stats() {Counts = _requestCount};
            }
        }
    }
}