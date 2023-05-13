using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Entidades.DTOs
{
    public class RolReadDto
    {
        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public RolReadDto()
        {
            
        }

        public RolReadDto(int id, string descripcion, bool estado, DateTime fecha) : this()
        {
            IdRolUsuario = id;
            Descripcion = descripcion;
            Estado = estado;
            FechaCreacion = fecha;
        }

    }
}
