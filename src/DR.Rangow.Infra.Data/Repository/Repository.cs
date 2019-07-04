using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DR.Rangow.Domain.Interfaces;
using DR.Rangow.Domain.Models;
using DR.Rangow.Infra.Data.Context;

namespace DR.Rangow.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected RangowContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new RangowContext();
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            this.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            var entry = Db.Entry<TEntity>(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            this.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var entity = new TEntity() { Id = id };
            DbSet.Remove(entity);

            this.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> ObterTodosPaginado(int pular, int intervalo)
        {
            return DbSet.Take(intervalo).Skip(pular);
        }

        public IEnumerable<TEntity> ObterTodosPaginadoPorColuna(int pular, int intervalo, Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Take(intervalo).Skip(pular).OrderBy(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
