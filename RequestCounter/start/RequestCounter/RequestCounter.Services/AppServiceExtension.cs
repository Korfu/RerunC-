using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestCounter.Services
{
    /// <summary>
    /// Use this class to register service
    /// </summary>
    public static class AppServiceExtension
    {
        public static void RegisterCounterService(this IServiceCollection collection)
        {
            collection.AddSingleton<IRequestCountStatsService, RequestCountStatisticsService>();
        }
    }
}