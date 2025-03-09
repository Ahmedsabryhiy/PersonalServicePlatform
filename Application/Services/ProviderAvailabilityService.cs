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
    public class ProviderAvailabilityService : BaseService<TbProviderAvailability, TbProviderAvailabilityDTO>, IProviderAvailabilityService
    {
        private readonly IGenericRepository<TbProviderAvailability> _repository;
        private readonly IMapper _mapper;
        public ProviderAvailabilityService(IGenericRepository<TbProviderAvailability> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
