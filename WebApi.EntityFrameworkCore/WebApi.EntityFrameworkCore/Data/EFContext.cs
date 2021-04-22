using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.EntityFrameworkCore.Models;

namespace WebApi.EntityFrameworkCore.Data
{
    public class EFContext : DbContext
    {
        public EFContext (DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public DbSet<WebApi.EntityFrameworkCore.Models.Contact> Contact { get; set; }
    }
}
