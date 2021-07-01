using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class EditModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public EditModel(CustomerDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet(int id)
        {
            Customer = new Customer()
            {
                Id = 1,
                Name = "Bob Mocked"
            };
        }
    }
}