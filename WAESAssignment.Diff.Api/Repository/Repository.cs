using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAESAssignment.Diff.Api.Interfaces.Repository;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.Diff.Api.Models;

namespace WAESAssignment.Diff.Api.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DiffDbContext _db;
        protected readonly DbSet<TModel> _dbSet;

        public Repository(DiffDbContext context)
        {
            _db = context;
            _dbSet = _db.Set<TModel>();
        }

        public async Task<TModel> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(TModel difference)
        {
            _dbSet.Add(difference);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
