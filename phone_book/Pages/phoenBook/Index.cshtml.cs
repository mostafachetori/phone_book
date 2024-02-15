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
    public class IndexModel : PageModel
    {
        private readonly phone_book.Data.phone_bookContext _context;

        public IndexModel(phone_book.Data.phone_bookContext context)
        {
            _context = context;
        }

        public IList<personInfo> personInfo { get;set; } = default!;

        public async Task OnGetAsync(string searching)
        {

            var phone_book = from b in _context.personInfo
                             select b;

            if (!String.IsNullOrEmpty(searching))
            {
                phone_book = _context.personInfo.Where(s => s.phoneNumber!.Contains(searching));
                
            }

            personInfo = await _context.personInfo.ToListAsync();
        }

    }
}
