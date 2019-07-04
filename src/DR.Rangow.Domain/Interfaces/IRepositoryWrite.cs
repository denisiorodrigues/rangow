using DR.Rangow.Domain.Models;
using System;

namespace DR.Rangow.Domain.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(Guid id);

        int SaveChanges();
    }
}
