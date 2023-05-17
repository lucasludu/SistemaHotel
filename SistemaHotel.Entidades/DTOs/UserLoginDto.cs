using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Entidades.DTOs
{
    public class UserLoginDto
    {
        public string? Correo { get; set; }
        public string? Clave { get; set; }

        public UserLoginDto()
        {
            
        }

        public UserLoginDto(string correo, string clave) : this()
        {
            Correo = correo;
            Clave = clave;
        }


    }
}
