﻿using Intercop.Services.Cliente.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Intercop.Services.Cliente.Infrastructure.Entity.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IRepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly Context db;

        public BaseRepository(Context _db)
        {
            db = _db;
        }

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
        }

        public void LoadReference(TEntity obj, Expression<Func<TEntity, object>> reference)
        {
            if (!(db.Entry(obj).Reference(reference).IsLoaded))
                db.Entry(obj).Reference(reference).Load();
        }

        public void LoadCollection(TEntity obj, Expression<Func<TEntity, IEnumerable<object>>> collection)
        {
            if (!(db.Entry(obj).Collection(collection).IsLoaded))
                db.Entry(obj).Collection(collection).Load();
        }

        public TEntity GetById(object id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return db.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate);
        }

        public void Commit()
        {
            try
            {
                db.SaveChanges();
            }

            catch (Exception)
            {
                throw new Exception("Error");
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
