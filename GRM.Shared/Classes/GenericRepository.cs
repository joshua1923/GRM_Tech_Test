using GRM.Shared.DataLayer;
using GRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GRM.Shared.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ContractsDBContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            _context = new ContractsDBContext();
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public void Add(IEnumerable<T> entity)
        {
            table.AddRange(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
