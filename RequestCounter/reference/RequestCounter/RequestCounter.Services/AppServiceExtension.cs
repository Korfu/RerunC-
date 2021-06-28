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
        /// <summary>
        /// This extension method is introduced with TASK Create statistics endpoint
        /// </summary>
        /// <param name="collection"></param>
        public static void RegisterCounerService(this IServiceCollection collection)
        {
            collection.AddSingleton<IRequestCountStatsService, RequestCountStatisticsService>();
        }
    }
}
