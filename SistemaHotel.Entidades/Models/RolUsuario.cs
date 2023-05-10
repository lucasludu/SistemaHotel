using System;
using System.Collections.Generic;

namespace SistemaHotel.Entidades.Models
{
    public partial class RolUsuario
    {
        public RolUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
