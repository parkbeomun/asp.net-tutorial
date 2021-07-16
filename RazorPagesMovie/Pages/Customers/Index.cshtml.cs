using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Customers
{
    public class IndexModel : PageModel
    {
        
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Console.WriteLine("id : "+ id);
            var contact = await _context.Customers.FindAsync(id);

            if (contact != null)
            {
                _context.Customers.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
        
    }
}