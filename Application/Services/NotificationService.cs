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
    public class NotificationService : BaseService<TbNotification, TbNotificattionDTO>, INotificationService
    {
        private readonly IGenericRepository<TbNotification> _repository;
        private readonly IMapper _mapper;
        public NotificationService(IGenericRepository<TbNotification> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
