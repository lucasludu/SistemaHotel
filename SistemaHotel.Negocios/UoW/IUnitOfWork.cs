using SistemaHotel.Negocios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRolNegocio Roles { get; }
        IUsuarioNegocio Usuarios { get; }
    }
}
