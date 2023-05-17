using AutoMapper;
using SistemaHotel.Entidades.DTOs;
using SistemaHotel.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Entidades.Mapper
{
    public class ConvertTo : Profile
    {
        public ConvertTo()
        {

            #region ROL
            CreateMap<RolWriteDto, RolUsuario>().ReverseMap();
            CreateMap<RolReadDto, RolUsuario>().ReverseMap();
            #endregion

            #region USUARIO
            CreateMap<UserLoginDto, Usuario>().ReverseMap();
            CreateMap<UserLoginDto, UserDto>().ReverseMap();
            CreateMap<UserRegisterDto, Usuario>().ReverseMap();
            CreateMap<UserDto, Usuario>().ReverseMap();
            #endregion

        }
    }
}
