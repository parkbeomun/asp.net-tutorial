using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Customers
{
    
    public class EditModel : PageModel
    {
        //db context 호출
        private readonly RazorPagesMovieContext _context;

        //class 생성자에서 context 초기화
        public EditModel(RazorPagesMovieContext context)
        {
            _context = context;
        }
        
        //model binding 
        //모델 바인딩이 해당 속성을 대상으로 하도록 컨트롤러의 공용 속성 또는 PageModel 에 적용
        //cshtml 에서 asp-for="Customer.Name" 과 같이 바인딩
        [BindProperty] 
        public Customer Customer { get; set; }

        //화면 호출(Customer 조회)
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        //Update
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!CustomerExists(Customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id.Equals(id));
        }
    }
}