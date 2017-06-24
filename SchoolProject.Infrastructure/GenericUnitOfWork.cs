using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure
{
    public class GenericUnitOfWork
    {
        private SchoolDbContext dbContext = new SchoolDbContext();
        public Type TheType { get; set; }

        public GenericRepository<TEntityType> GetInstance<TEntityType>() where TEntityType : class
        {
            return new GenericRepository<TEntityType>(dbContext);
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
