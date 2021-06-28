using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationRazor.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly IConfiguration Configuration;
        
        public IndexModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            return Content(Configuration["ConnectionStringDB"]);
        }
    }
}
