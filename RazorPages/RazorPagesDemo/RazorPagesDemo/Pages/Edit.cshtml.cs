using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> OnGet(int id)
        {
            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return RedirectToPage("./Index");
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer {Customer.Id} not found!");
            }

            return RedirectToPage("./Index");
        }
    }
}