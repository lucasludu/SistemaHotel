using System;
using System.Collections.Generic;

namespace SistemaHotel.Entidades.Models
{
    public partial class EstadoHabitacion
    {
        public EstadoHabitacion()
        {
            Habitacions = new HashSet<Habitacion>();
        }

        public int IdEstadoHabitacion { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Habitacion> Habitacions { get; set; }
    }
}
