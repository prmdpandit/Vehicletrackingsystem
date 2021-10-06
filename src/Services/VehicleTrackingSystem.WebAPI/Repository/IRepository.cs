using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTrackingSystem.WebAPI.Entities;

namespace VehicleTrackingSystem.WebAPI.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
