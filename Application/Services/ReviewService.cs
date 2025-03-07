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
    public class ReviewService : BaseService<TbReview, TbReviewDTO>, IReviewService
    {
        private readonly IGenericRepository<TbReview> _repository;
        private readonly IMapper _mapper;
        public ReviewService(IGenericRepository<TbReview> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
