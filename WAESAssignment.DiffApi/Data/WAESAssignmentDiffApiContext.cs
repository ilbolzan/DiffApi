using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAESAssignment.Diff.Api.Model;

namespace WAESAssignment.Diff.Api.Models
{
    public class WAESAssignmentDiffApiContext : DbContext
    {
        public WAESAssignmentDiffApiContext (DbContextOptions<WAESAssignmentDiffApiContext> options)
            : base(options)
        {
        }

        public DbSet<WAESAssignment.Diff.Api.Model.Difference> Difference { get; set; }
    }
}
