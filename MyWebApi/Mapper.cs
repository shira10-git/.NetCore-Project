using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;
using Repositories;

namespace MyWebApi
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.OrderItems,
                 opts => opts.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.OrderDate, opts => opts.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.OrderSum, opts => opts.MapFrom(src => src.OrderItems.Sum(item => item.Quentity * item.price)));
     
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.Category,
                opts => opts.MapFrom(src => src.Category.CategoryName));

            CreateMap<Category, CtegoryDTO>(); 

            CreateMap<User, UserDTO>();

            CreateMap<User, UserAfterLoginDTO>();

            CreateMap<RegisterDTO, User>(); 
            
            CreateMap < Order, OrderAfterDTO > ();

        }
    }
   
}
