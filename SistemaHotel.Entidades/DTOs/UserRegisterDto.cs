using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Entidades.DTOs
{
    public class UserRegisterDto
    {
        public int? Id { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Nombre { get; set; }
        public string Apellido { get; set; } = null!;
        public string? Clave { get; set; }


        public UserRegisterDto()
        {
            
        }

        public UserRegisterDto(int id, string nombre, string apellido, string correo, int idRol, string clave) : this()
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            IdRolUsuario = idRol;
            Clave = clave;
        }

    }
}
