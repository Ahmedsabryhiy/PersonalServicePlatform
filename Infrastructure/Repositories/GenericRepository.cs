using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Contracts;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseTable
    {
       private readonly PersonServicePlatformContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(PersonServicePlatformContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }
        public List<T> GetAll()
        {
            try
            {
                return _dbSet.Where(a => a.CurrentState == 1).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Failed to retrieve data: {Message }", ex.Message);
                throw new DataAccessException(ex, "GetAll", _logger);
            }

        }
        public T GetById(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(a => a.CurrentState == 1).
                FirstOrDefault(a => a.Id == id);
            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity of type {Type}", typeof(T).Name);
                throw new DataAccessException(ex, "Add", _logger); // Ensure inner exception is logged
            }
        }
        public  bool  Add(T entity)
        {
           try
            {
                entity.CurrentState = 1;
                entity.CreatedDate = DateTime.Now;
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
           catch (Exception ex)
                {
                    _logger.LogError(ex, "Error adding entity of type {Type}", typeof(T).Name);
                    throw new DataAccessException(ex, "Add", _logger); // Ensure inner exception is logged
                }
        }
        public bool  Update(T entity)
        {
            // Find the existing (tracked) entity from the database using the primary key
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity == null)
            {
                throw new Exception($"Data not found for ID: {entity.Id}");
            }

            try
            {
                // Update the tracked entity with values from the new instance.
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);

                // Set audit fields explicitly (e.g., UpdatedDate and UpdatedBy)
                existingEntity.UpdatedDate = DateTime.Now;
                existingEntity.UpdatedBy = "Admin"; // Ensure you're updating the proper field
                existingEntity.CreatedBy = "System";

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "Update", _logger);
            }
        }
        public  bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            try
            {
                //  entity.CurrentState = 0;
                entity.UpdatedDate = DateTime.Now;
               
                _dbSet.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error  deleting entity of type {Type}", typeof(T).Name);
                throw new DataAccessException(ex, "Add", _logger); // Ensure inner exception is logged
            }
        }

    }
}
