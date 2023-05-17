using SistemaHotel.Entidades.Models;
using SistemaHotel.Negocios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.Repositorios
{
    public class RolNegocio : BaseNegocio<RolUsuario>, IRolNegocio
    {
        public bool Desactivar(int id)
        {
            var rol = this.Context.RolUsuarios.Find(id);
            if(rol != null)
            {
                rol.Estado = false;
            }
            return this.Context.SaveChanges() > 0;
        }


        public bool Activar(int id)
        {
            var rol = this.Context.RolUsuarios.Find(id);
            if (rol != null)
            {
                rol.Estado = true;
            }
            return this.Context.SaveChanges() > 0;
        }
    }
}
