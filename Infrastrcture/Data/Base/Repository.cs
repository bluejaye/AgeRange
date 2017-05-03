using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
    public class Repository<Key, Entity> : IRepository<Key, Entity> where Entity : class, new()
    {
        /// <summary>
        /// Current EF DBContext instance.
        /// </summary>
        protected virtual AgeRangerDbContext Context { get; set; }

        /// <summary>
        /// DBSet of <see cref="Entity"/> extracted from <see cref="Context"/>.
        /// </summary>
        internal DbSet<Entity> DbSet;

        public Repository(AgeRangerDbContext dbContext)
        {
            //initialize db context
            Context = dbContext;

            // Configures current entity DB Set which is being manipulated
            DbSet = dbContext.Set<Entity>();
        }

        public virtual void Delete(Key id)
        {
            Delete(this.Get(id));
        }

        public virtual void Delete(Entity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
        }

        public virtual Entity Edit(Entity entityToUpdate)
        {
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }

        public virtual Entity Get(Key key)
        {
            return DbSet.Find(key);
        }

        public virtual Entity Insert(Entity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual IQueryable<Entity> ListAll()
        {
            return DbSet;
        }

        public virtual IQueryable<Entity> List()
        {
            return this.ListAll();
        }
    }
}
