using AutoMapper;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<AddressCreationDTO, Address>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserCreationDTO, User>();
            CreateMap<Item,ItemDTO>().ReverseMap();
            CreateMap<ItemCreationDTO,Item>();
            CreateMap<Item,ItemPatchDTO>().ReverseMap();
            CreateMap<Address,AddressPatchDTO>().ReverseMap();
            CreateMap<Order,OrderDTO>().ReverseMap();
            CreateMap<OrderCreationDTO,Order>();
            CreateMap<Order,OrderPatchDTO>().ReverseMap();
        }
    }
}
