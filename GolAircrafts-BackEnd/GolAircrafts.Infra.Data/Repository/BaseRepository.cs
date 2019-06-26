using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GolAirCrafts.Domain.Entities;
using GolAirCrafts.Domain.Interfaces.Repositories;
using GolAirCrafts.Infra.Data.Context;

namespace GolAirCrafts.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //public readonly MySqlContext _context;

        public readonly ContextDb _context;

        public BaseRepository(ContextDb context)
        {
            _context = context;
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<T>().Remove(Select(id));
            _context.SaveChanges();
        }

        public T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IList<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
