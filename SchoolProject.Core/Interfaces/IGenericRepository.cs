using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public interface IGenericRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable GetAllRecords();
        TEntity GetFirstOrDefault(int recordId);
    }
}
