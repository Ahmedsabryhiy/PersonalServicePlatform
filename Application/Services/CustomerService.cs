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
    public class CustomerService : BaseService<TbCustomer, TbCustomerProfileDTO>, ICustomerService
    {
        private readonly IGenericRepository<TbCustomer> _repository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<TbCustomer> repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
    }
}
