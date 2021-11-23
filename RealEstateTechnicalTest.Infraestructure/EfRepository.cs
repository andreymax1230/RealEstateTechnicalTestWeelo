﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstateTechnicalTest.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RealEstateTechnicalTest.Infraestructure
{
    /// <summary>
    /// Represents the Entity Framework repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected readonly Entities _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor

        public EfRepository(Entities entities)
        {
            _context = entities;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            Entities.AddRange(entities);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));


            ((DbContext)_context).Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (TEntity entity in entities)
            {
                this.Entities.Attach(entity);
                ((DbContext)_context).Entry(entity).State = EntityState.Modified;
            }
        }



        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.RemoveRange(entities);
        }


        public void Delete(Expression<Func<TEntity, bool>> where)
        {

            IEnumerable<TEntity> objects = Entities.Where(where).AsEnumerable();
            foreach (TEntity obj in objects)
            {
                Entities.Attach(obj);
                Entities.Remove(obj);
            }
        }


        /// <summary>
        /// Gets all entities of type T
        /// </summary>
        /// <returns>Entities</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        /// <summary>
        /// Gets entities using delegate
        /// </summary>
        /// <param name="where">Expression</param>
        /// <returns>Entities</returns>
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return Entities.Where(where).ToList();
        }

        /// <summary>
        /// Get an entity using delegate
        /// </summary>
        /// <param name="where">Expression</param>
        /// <returns>Entity</returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return Entities.Where(where).FirstOrDefault();
        }
        /// <summary>
        /// Get count of entities
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return this.Entities.Where(where).Count();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        #endregion
    }
}
