using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RequestCounter.Services;
using RequestCounter.WebApp.Model;

namespace RequestCounter.WebApp.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly IRequestCountStatsService requestCountStatsService;

        public StatisticsModel(IRequestCountStatsService service)
        {
            this.requestCountStatsService = service;
        }

        [BindProperty]
        public StatsSummary StatsSummary { get; set; }

        public void OnGet()
        {
            var stats = this.requestCountStatsService.GetStatistics();

            StatsSummary = new StatsSummary()
            {
                StatisticsEntries = stats.Counts.Select(x => new StatisticsEntry()
                {
                    ExecutionCount = x.Value,
                    Method = x.Key
                }).ToList()
            };
        }
    }
}
