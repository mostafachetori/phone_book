using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using phone_book.Data;
using phone_book.Models;

namespace phone_book.Pages.phoenBook
{
    public class CreateModel : PageModel
    {
        private readonly phone_book.Data.phone_bookContext _context;

        public CreateModel(phone_book.Data.phone_bookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public personInfo personInfo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.personInfo == null || personInfo == null)
            {
                return Page();
            }

            _context.personInfo.Add(personInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
