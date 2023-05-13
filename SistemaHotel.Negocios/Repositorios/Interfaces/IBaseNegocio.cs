using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel.Negocios.Repositorios.Interfaces
{
    public interface IBaseNegocio<T> where T : class
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
        T GetById(int id);
        T GetByCondition(Expression<Func<T, bool>> condition);
        List<T> GetAll();
        List<T> GetAllByCondition(Expression<Func<T, bool>> condition);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
