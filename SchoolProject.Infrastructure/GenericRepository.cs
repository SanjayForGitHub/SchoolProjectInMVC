using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace SchoolProject.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> dbSet;
        private SchoolDbContext dbContext;
        public GenericRepository(SchoolDbContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public IEnumerable GetAllRecords()
        {
            return dbSet.ToList();
        }

        public TEntity GetFirstOrDefault(int recordId)
        {
            return dbSet.Find(recordId);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
