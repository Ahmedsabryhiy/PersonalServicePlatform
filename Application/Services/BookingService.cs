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
    public class BookingService : BaseService<TbBooking, TbBookingDTO>, IBookingService
    {
        private readonly IGenericRepository<TbBooking> _repository;
        private readonly IMapper _mapper;
        public BookingService(IGenericRepository<TbBooking> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }
    }
}
