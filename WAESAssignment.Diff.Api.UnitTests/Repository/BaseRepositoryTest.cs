using System;
using System.Collections.Generic;
using System.Text;
using WAESAssignment.Diff.Api.Models;
using WAESAssignment.Diff.Api.UnitTests.Helpers;

namespace WAESAssignment.Diff.Api.UnitTests.Repository
{
    public abstract class BaseRepositoryTest : IDisposable
    {
        protected readonly DiffDbContext _context;
        public BaseRepositoryTest()
        {
            var options = DbContextOptionsHelper.CreateOptions<DiffDbContext>();
            _context = new DiffDbContext(options);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
