using System;
using System.Collections.Generic;

namespace SistemaHotel.Entidades.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Recepcions = new HashSet<Recepcion>();
        }

        public int IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Recepcion> Recepcions { get; set; }
    }
}
