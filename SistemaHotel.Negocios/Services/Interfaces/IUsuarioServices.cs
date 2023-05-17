using SistemaHotel.Entidades.DTOs;
using SistemaHotel.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.Services.Interfaces
{
    public interface IUsuarioServices
    {
        UserRegisterDto Register(UserRegisterDto userregister, string password);
        UserDto Login(UserLoginDto userLogin);
        string GetToken(UserDto user);
    }
}
