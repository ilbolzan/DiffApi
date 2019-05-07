using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAESAssignment.Diff.Api.Entity;

namespace WAESAssignment.Diff.Api.Models
{
    public class DiffDbContext : DbContext
    {
        public DiffDbContext (DbContextOptions<DiffDbContext> options)
            : base(options)
        {
        }

        public DbSet<DifferenceLeft> DifferenceLeft { get; set; }
        public DbSet<DifferenceRight> DifferenceRight { get; set; }
    }
}
