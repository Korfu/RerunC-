using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task OnGet()
        {
            Customers = await _dbContext.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var contact = await _dbContext.Customers.FindAsync(id);

            if (contact != null)
            {
                _dbContext.Remove(contact);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
