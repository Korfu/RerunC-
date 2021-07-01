using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CustomerDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, CustomerDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        
        public IList<Customer> Customers { get; set; }

        public void OnGet()
        {
            Customers = new List<Customer>();
        }
    }
}
