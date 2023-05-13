using SistemaHotel.Negocios.Repositorios;
using SistemaHotel.Negocios.Repositorios.Interfaces;

namespace SistemaHotel.Negocios.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Propiedades Privados

        private IRolNegocio? roles;
        private IUsuarioNegocio? usuarios;

        #endregion

        #region Constructor

        public UnitOfWork()
        {
            
        }

        #endregion

        #region Propiedades Publicas

        public IRolNegocio Roles
        {
            get
            {
                return roles ?? (roles = new RolNegocio());
            }
        }


        public IUsuarioNegocio Usuarios
        {
            get
            {
                return usuarios ?? (usuarios = new UsuarioNegocio());
            }
        }

        #endregion

        public void Dispose()
        {
        }

    }
}
