﻿using System;
using System.Collections.Generic;

namespace SistemaHotel.Entidades.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Apellido { get; set; } = null!;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public virtual RolUsuario? IdRolUsuarioNavigation { get; set; }
    }
}
