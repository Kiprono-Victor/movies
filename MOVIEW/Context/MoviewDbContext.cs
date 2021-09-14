using Microsoft.EntityFrameworkCore;
using MOVIEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIEW.Context
{
    public class MoviewDbContext : DbContext
    {
        public MoviewDbContext(DbContextOptions<MoviewDbContext> options)
            : base(options)
        {
        }
        public DbSet<Register> registers { get; set; }
        public DbSet<MOVIEW.Models.Movies> Movies { get; set; }
        public DbSet<MOVIEW.Models.Price> Order_Db { get; set; }
    }
}
