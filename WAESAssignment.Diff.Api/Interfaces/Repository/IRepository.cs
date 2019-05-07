using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAESAssignment.Diff.Api.Entity;

namespace WAESAssignment.Diff.Api.Interfaces.Repository
{
    public interface IRepository<TModel> : IDisposable where TModel : class
    {
        void Add(TModel difference);
        Task<TModel> GetById(int id);
    }
}
