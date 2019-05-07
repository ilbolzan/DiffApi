using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAESAssignment.Diff.Api.Interfaces.Repository;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.Diff.Api.Models;

namespace WAESAssignment.Diff.Api.Repository
{
    public class DifferenceLeftRepository : Repository<DifferenceLeft>, IDifferenceLeftRepository
    {
        public DifferenceLeftRepository(DiffDbContext context) : base(context)
        {

        }
    }
}
