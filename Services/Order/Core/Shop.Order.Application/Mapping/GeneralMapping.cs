using AutoMapper;
using Shop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Shop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Shop.Order.Application.Features.CQRS.Results.AddressResults;
using Shop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Shop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Shop.Order.Application.Features.Mediator.Results.OrderingResults;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, GetAddressByIdQueryResult>().ReverseMap();
            CreateMap<Address, GetAddressByUserIdQueryResult>().ReverseMap();
            CreateMap<Address, GetAddressQueryResult>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();

            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailByIdQueryResult>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailByOrderingIdQueryResult>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailQueryResult>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();

            CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();
            CreateMap<Ordering, GetOrderingByIdQueryResult>().ReverseMap();
            CreateMap<Ordering, GetOrderingByUserIdQueryResult>().ReverseMap();
            CreateMap<Ordering, GetOrderingQueryResult>().ReverseMap();
            CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();
        }
    }
}
