using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Entities;
using MovieApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => 
            context.Set<TEntity>().Where(predicate);

        public IEnumerable<TEntity> GetAll() => 
            context.Set<TEntity>().ToList();

        public TEntity GetById(int id) => 
            context.Set<TEntity>().Find(id);

        public void Add(TEntity entity) =>
            context.Set<TEntity>().Add(entity);

        public void Remove(TEntity entity) => 
            context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) =>
            context.Entry(entity).State = EntityState.Modified;
    }
}
