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
            CreateMap<RolWriteDto, RolUsuario>().ReverseMap();
            CreateMap<RolReadDto, RolUsuario>().ReverseMap();
        }
    }
}
