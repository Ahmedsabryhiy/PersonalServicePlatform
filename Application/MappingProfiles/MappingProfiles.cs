using Application.Dots;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public  class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //AddProfile(new MappingProfile());
            CreateMap<TbCustomer, TbCustomerProfileDTO>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
                .ReverseMap();
   

            CreateMap<TbProvider, TbProviderProfileDTO>()
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
             .ReverseMap();
            CreateMap<TbCategory, TbCategoryDTO>() 
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0)) 
             .ReverseMap();
            CreateMap<TbReview, TbReviewDTO>()
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
             .ReverseMap();
            CreateMap<TbBooking, TbBookingDTO>()    
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
             .ReverseMap();
            CreateMap<TbService, TbServiceDTO>()    
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
             .ReverseMap();
            CreateMap<TbNotification, TbNotificattionDTO>()
            .ForMember(dest=> dest.Id, opt => opt.Condition(src => src.Id != 0)).ReverseMap();
            CreateMap <TbProviderAvailability, TbProviderAvailabilityDTO>()
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
             .ReverseMap();
            CreateMap <TbPayment, TbPaymentDTO>()
             .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
             .ReverseMap();
           
        }
    }
}
