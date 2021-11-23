using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateTechnicalTest.Infraestructure.Configuration;

namespace RealEstateTechnicalTest.Infraestructure
{
    public partial class Entities : IdentityDbContext
    {
        #region Ctor
        private readonly IHttpContextAccessor _contextAccessor;
        public Entities()
        {
        }

        public Entities(DbContextOptions<Entities> options, IHttpContextAccessor contextAccessor = null) : base(options)
        {
            _contextAccessor = contextAccessor;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Further configuration the model
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OwnerConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new PropertyImageConfiguration());
            builder.ApplyConfiguration(new PropertyTraceConfiguration());
            base.OnModelCreating(builder);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


        /// <summary>
        /// Creates a LINQ query for the query type based on a raw SQL query
        /// </summary>
        /// <typeparam name="TQuery">Query type</typeparam>
        /// <param name="sql">The raw SQL query</param>
        /// <returns>An IQueryable representing the raw SQL query</returns>
        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class
        {
            return this.Set<TQuery>().FromSqlRaw(sql);
        }

        /// <summary>
        /// Detach an entity from the context
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity</param>
        public virtual void Detach<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = this.Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }


        #endregion
    }
}
