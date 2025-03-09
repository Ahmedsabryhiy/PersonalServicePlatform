using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBaseService<T,DTO> 
    {
        public List<DTO> GetAll();
        public DTO GetById(int id);
        public bool Add(DTO entity);
        public bool Update(DTO entity);
        public bool Delete(int id);
    }
}
