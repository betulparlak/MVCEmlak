using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcEmlak.Models;

namespace MvcEmlak.Models
{
    public class MvcEmlakContext : DbContext
    {
        public MvcEmlakContext(DbContextOptions<MvcEmlakContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEmlak.Models.User> User { get; set; }

        public DbSet<MvcEmlak.Models.Emlak> Emlak { get; set; }
    }
}
