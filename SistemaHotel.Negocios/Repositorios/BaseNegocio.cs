using SistemaHotel.Negocios.Contexto;
using SistemaHotel.Negocios.Repositorios.Interfaces;
using System.Linq.Expressions;

namespace SistemaHotel.Negocios.Repositorios
{
    public class BaseNegocio<T> : BLLContext, IBaseNegocio<T> where T : class
    {

        #region CONSULTAS

        public List<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = this.Context.Set<T>().AsQueryable();
            query = PrepareQuery(query, predicate, orderBy);
            return query.ToList();
        }

        public List<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            return this.Context.Set<T>().Where(condition).ToList();
        }

        public T GetByCondition(Expression<Func<T, bool>> condition)
        {
            return this.Context.Set<T>().Where(condition).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return this.Context.Set<T>().Find(id);
        }

        #endregion

        #region ABM

        public bool Save()
        {
            return this.Context.SaveChanges() > 0;
        }

        public bool Insert(T entity)
        {
            this.Context.Set<T>().Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            this.Context.Update(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            this.Context.Remove(entity);
            return Save();
        }

        #endregion

        #region PRIVADO

        protected IQueryable<T> PrepareQuery(IQueryable<T> query, 
                                            Expression<Func<T, bool>> predicate = null, 
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            if(predicate != null) 
                query = query.Where(predicate);
            if (orderBy != null) 
                query = orderBy(query);

            return query;
        }

        #endregion

    }
}
