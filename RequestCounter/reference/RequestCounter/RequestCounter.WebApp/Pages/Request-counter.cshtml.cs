using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RequestCounter.Services;

namespace RequestCounter.WebApp.Pages
{
    public class Request_counterModel : PageModel
    {
        private const string GetMethod = "GET";
        private const string PoseMethod = "POST";
        private IRequestCountStatsService requestCountStatsService;

        public Request_counterModel(IRequestCountStatsService service)
        {
            this.requestCountStatsService = service;
        }
        
        public ActionResult OnGet()
        {
            this.requestCountStatsService.IncreaseCounter(GetMethod);
            return Redirect("/");
        }
        
        public ActionResult OnPost()
        {
            this.requestCountStatsService.IncreaseCounter(PoseMethod);
            return Redirect("/");
        }
    }
}
