using DR.Rangow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DR.Rangow.Domain.Interfaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        IEnumerable<TEntity> ObterTodosPaginado(int pagina, int qtdRegistro);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}
