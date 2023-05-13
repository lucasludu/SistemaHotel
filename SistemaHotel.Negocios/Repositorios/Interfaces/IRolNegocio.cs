using SistemaHotel.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.Repositorios.Interfaces
{
    public interface IRolNegocio : IBaseNegocio<RolUsuario>
    {
        bool Desactivar(int id);
    }
}
