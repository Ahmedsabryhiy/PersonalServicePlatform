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
    public class ServicesService : BaseService<TbService, TbServiceDTO>, IServicesService
    {
        private readonly IGenericRepository<TbService> _repository;
        private readonly IMapper _mapper;
        public ServicesService(IGenericRepository<TbService> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public List<TbServiceDTO> GetByCategory(int categoryId)
        {
         var list = _repository.GetAll().Where(s => s.CategoryId == categoryId).ToList();
            return _mapper.Map<List<TbService>, List<TbServiceDTO>>(list);
        }

        public List<TbServiceDTO> Search(string searchTerm)
        {
            var services =new List<TbService>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                 services = _repository.GetAll().
                     Where(s => s.Name.Contains(searchTerm) || s.Description.Contains(searchTerm)).ToList();

            }
            return _mapper.Map<List<TbService>, List<TbServiceDTO>>(services);
        }
    }
}
