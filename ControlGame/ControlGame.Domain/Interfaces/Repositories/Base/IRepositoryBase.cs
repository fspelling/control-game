using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControlGame.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId> where TEntidade : class where TId : struct
    {
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarOrdenarPor<TKey>(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        bool Existe(Func<TEntidade, bool> where);

        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade Adicionar(TEntidade entidade);

        TEntidade Alterar(TEntidade entidade);

        TEntidade Remover(TEntidade entidade);

        IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades);
    }
}
