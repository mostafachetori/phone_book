using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phone_book.Data;
using phone_book.Models;

namespace phone_book.Pages.phoenBook
{
    public class EditModel : PageModel
    {
        private readonly phone_book.Data.phone_bookContext _context;

        public EditModel(phone_book.Data.phone_bookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public personInfo personInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.personInfo == null)
            {
                return NotFound();
            }

            var personinfo =  await _context.personInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (personinfo == null)
            {
                return NotFound();
            }
            personInfo = personinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(personInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personInfoExists(personInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool personInfoExists(int id)
        {
          return (_context.personInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
