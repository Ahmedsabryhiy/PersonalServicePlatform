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
    public class PaymentService : BaseService<TbPayment, TbPaymentDTO>, IPaymentService
    {
        private readonly IGenericRepository<TbPayment> _repository;
        private readonly IMapper _mapper;
        public PaymentService(IGenericRepository<TbPayment> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
