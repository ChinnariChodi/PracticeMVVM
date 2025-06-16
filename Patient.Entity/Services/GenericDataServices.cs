using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatientApplication.Domain.Models;
using PatientApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Entity.Services
{
    public class GenericDataServices<T> : IDataService<T> where T : Patients
    {
        private readonly PatientDbContextFactory _dataContext;

        public GenericDataServices(PatientDbContextFactory dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> Create(T entity)
        {
            using (PatientDbContext context = _dataContext.CreateDbContext())
            {
                EntityEntry<T> createEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (PatientDbContext context = _dataContext.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (PatientDbContext context = _dataContext.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (PatientDbContext context = _dataContext.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (PatientDbContext context = _dataContext.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        Task<T> IDataService<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
