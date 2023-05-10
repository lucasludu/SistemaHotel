using System;
using System.Collections.Generic;

namespace SistemaHotel.Entidades.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Habitacions = new HashSet<Habitacion>();
        }

        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Habitacion> Habitacions { get; set; }
    }
}
