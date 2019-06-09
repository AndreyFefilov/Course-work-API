using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.Models.EnitiesDTO;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<CreationMessageDTO, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDTO>();

        }
    }
}
