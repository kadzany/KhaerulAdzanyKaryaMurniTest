using Data;
using Data.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {

        private readonly TodoContext _context;

        public BaseService(TodoContext context)
        {
            _context = context;
        }

        public virtual T Delete(int id)
        {
            try
            {
                var existingEntity = GetById(id);

                _context.Set<T>().Remove(existingEntity);
                _context.SaveChanges();

                return existingEntity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                var result = from i in _context.Set<T>()
                             select i;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                var result = (from i in _context.Set<T>()
                              where i.Id == id
                              select i).FirstOrDefault();

                if (result == null) throw new Exception("Data not found!");

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual int Insert(T entity)
        {
            try
            {
                entity.CreatedBy = "system";
                entity.CreatedAt = DateTime.UtcNow;
                var result = _context.Add(entity);

                _context.SaveChanges();

                return result.Entity.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual T Update(int id, T entity)
        {
            try
            {
                var existingEntity = GetById(id);

                // simplest mapping
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name == "Id") continue;

                    var input = prop.GetValue(entity);

                    if (input != null && !string.IsNullOrEmpty(input.ToString()))
                    {
                        existingEntity.GetType().GetProperty(prop.Name).SetValue(existingEntity, input);
                    }
                }

                existingEntity.UpdatedBy = "system";
                existingEntity.UpdatedAt = DateTime.UtcNow;

                var result = _context.Update(existingEntity);

                _context.SaveChanges();

                return result.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
