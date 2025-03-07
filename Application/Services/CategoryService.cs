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
    public class CategoryService : BaseService<TbCategory, TbCategoryDTO>, ICategoryService
    {
        private readonly IGenericRepository<TbCategory> _repository;
        private readonly IMapper _mapper;
       
        public CategoryService(IGenericRepository<TbCategory> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
