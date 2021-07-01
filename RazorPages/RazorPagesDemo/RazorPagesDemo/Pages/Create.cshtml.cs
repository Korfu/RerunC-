using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public CreateModel(CustomerDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {
            
        }
    }
}