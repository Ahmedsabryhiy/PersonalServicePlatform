using Application.Contracts;
using Application.Dots;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BaseService<T,DTO> : IBaseService<T,DTO> where T : BaseTable
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;
        public BaseService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }  

        public List<DTO> GetAll()
        {
            var list = _repository.GetAll();
            return _mapper.Map<List<T>,List<DTO>>(list);

        }
        public DTO GetById(int id)
        {
            var item = _repository.GetById(id);
            return _mapper.Map<T,DTO>(item);
        }
        public bool Add(DTO entity)
        {
            var item = _mapper.Map<DTO, T>(entity);
             item.CreatedDate = DateTime.Now;
             item.CreatedBy = "Admin";
            return _repository.Add(item);
        }

        public bool Update(DTO entity)
        {
            var item = _mapper.Map<DTO, T>(entity);
            item.UpdatedDate = DateTime.Now;
            item.CurrentState = 1;
            item.UpdatedBy = "Admin";
            return _repository.Update(item);
            
        }

        public bool Delete(int id)
        {
       
            return _repository.Delete(id);
        }

    }
}
