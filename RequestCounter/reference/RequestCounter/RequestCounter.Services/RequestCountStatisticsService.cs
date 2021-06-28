using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.Services
{
    public class RequestCountStatisticsService : IRequestCountStatsService
    {
        /// <summary>
        /// Use this object for locking access to critical section. 
        /// Critical section is this part of code which should be executed sequentially even in multithreaded environment.
        /// Usualy it applies in situations when reading modification and writing to same property/resource takes place.
        /// </summary>
        private readonly object objectLock = new object();
                
        private static readonly string[] AllowedMethods = new string[] { "GET", "POST", "DELETE", "PATCH", "PUT" };

        private Dictionary<string, int> stats = new Dictionary<string, int>();

        public Stats GetStatistics()
        {
            lock (objectLock)
            {
                //Following line is introduced with TASK "Save counts"
                this.stats = DataReader.ReadFromFile();
            }

            return new Stats() { Counts = this.stats };
        }

        public void IncreaseCounter(string method)
        {
            if (AllowedMethods.Any(x=> x == method))
            {
                lock (objectLock)
                {
                    //Following line is introduced with TASK "Save counts"
                    this.stats = DataReader.ReadFromFile();
                    if (stats.ContainsKey(method))
                    {
                        stats[method] += 1;
                    }
                    else
                    {
                        stats[method] = 1;
                    }

                    //Following line is introduced with TASK "Save counts"
                    DataReader.WriteToFile(this.stats);
                }
               
            }
            else
            {
                throw new InvalidOperationException($"Not allowed method  GOT: {method}");
            }
        }
    }
}
