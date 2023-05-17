using SistemaHotel.Entidades.Models;
using SistemaHotel.Negocios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.Repositorios
{
    public class UsuarioNegocio : BaseNegocio<Usuario>, IUsuarioNegocio
    {


        public bool ExisteUsuario(string email)
        {
            return this.Context.Usuarios.Any(a => a.Correo.Trim().ToLower().Equals(email.Trim().ToLower()));
        }
    }
}
