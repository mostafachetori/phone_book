using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using phone_book.Models;

namespace phone_book.Data
{
    public class phone_bookContext : DbContext
    {
        public phone_bookContext (DbContextOptions<phone_bookContext> options)
            : base(options)
        {
        }

        public DbSet<phone_book.Models.personInfo> personInfo { get; set; } = default!;
    }
}
