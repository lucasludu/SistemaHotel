using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Entidades.DTOs
{
    public class RolWriteDto
    {
        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }


        public RolWriteDto()
        {
            
        }


        public RolWriteDto(int id, string descripcion) : this()
        {
            IdRolUsuario = id;
            Descripcion  = descripcion; 
        }
    }
}
