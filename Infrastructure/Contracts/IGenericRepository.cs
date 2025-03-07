using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IGenericRepository <T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Delete( int id);

    }
}
