using System.Collections.Generic;
using GolAirCrafts.Domain.Entities;

namespace GolAirCrafts.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove(int id);

        T Select(int id);

        IList<T> SelectAll();
    }
}
