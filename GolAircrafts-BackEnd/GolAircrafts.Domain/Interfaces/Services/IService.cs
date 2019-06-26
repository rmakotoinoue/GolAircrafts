using FluentValidation;
using System.Collections.Generic;
using GolAirCrafts.Domain.Entities;

namespace GolAirCrafts.Domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
    {
        T Insert<V>(T obj) where V : AbstractValidator<T>;

        T Update<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        T GetById(int id);

        IList<T> GetAll();
    }
}
