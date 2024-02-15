using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using phone_book.Data;
using phone_book.Models;

namespace phone_book.Pages.phoenBook
{
    public class DetailsModel : PageModel
    {
        private readonly phone_book.Data.phone_bookContext _context;

        public DetailsModel(phone_book.Data.phone_bookContext context)
        {
            _context = context;
        }

      public personInfo personInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.personInfo == null)
            {
                return NotFound();
            }

            var personinfo = await _context.personInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (personinfo == null)
            {
                return NotFound();
            }
            else 
            {
                personInfo = personinfo;
            }
            return Page();
        }
    }
}
