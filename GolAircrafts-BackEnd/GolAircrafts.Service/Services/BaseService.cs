using FluentValidation;
using System;
using System.Collections.Generic;
using GolAirCrafts.Domain.Entities;
using GolAirCrafts.Domain.Interfaces.Repositories;
using GolAirCrafts.Domain.Interfaces.Services;

namespace GolAirCrafts.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }


        public T Insert<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser zerado");

            _repository.Remove(id);
        }

        public IList<T> GetAll() => _repository.SelectAll();

        public T GetById(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser zerado");

            return _repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registro não detectado");

            validator.ValidateAndThrow(obj);
        }
    }
}
