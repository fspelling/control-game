using ControlGame.Domain.Entity.Base;
using ControlGame.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ControlGame.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId> where TEntidade : EntityBase where TId : struct
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Add(entidade);
        }

        public IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            return _context.Set<TEntidade>().AddRange(entidades);
        }

        public TEntidade Alterar(TEntidade entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            return entidade;
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();
            return query;
        }

        public IQueryable<TEntidade> ListarOrdenarPor<TKey>(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public TEntidade ObterPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
                return Listar(includeProperties).FirstOrDefault(p => p.Id.ToString() == id.ToString());

            return _context.Set<TEntidade>().Find(id);
        }

        public TEntidade Remover(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Remove(entidade);
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var prop in includeProperties)
                query.Include(prop);

            return query;
        }
    }
}
