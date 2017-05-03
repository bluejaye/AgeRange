using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contract
{
    /// <summary>
    /// Repository interface to be implemented by the persistence class.
    /// </summary>
    /// <typeparam name="Key">The key type of current entity type.</typeparam>
    /// <typeparam name="Entity">The type of the data being persisted or retreived.</typeparam>
    public interface IRepository<Key, Entity> where Entity : class
    {
        /// <summary>
        /// Lists all database records for an entity. * Use this carefully.
        /// </summary>
        /// <returns>
        /// Collection of all persisted entities.
        /// </returns>
        IQueryable<Entity> ListAll();

        /// <summary>
        /// Gets an entity instance based on its Key.
        /// </summary>
        /// <param name="key">The desired entity key value.</param>
        /// <returns>Persisted entity if found, otherwise NULL.</returns>
        Entity Get(Key id);


        /// <summary>
        /// Inserts a new entity to database.
        /// </summary>
        /// <param name="entity">The new <see cref="Entity"/> instance to be persisted.</param>
        /// <returns>
        /// The recently inserted entity and its database id.
        /// </returns>
        Entity Insert(Entity entity);

        /// <summary>
        /// Deletes an existing entity.
        /// </summary>
        /// <param name="id">The primary key of the <see cref="Entity"/> to be deleted.</param>
        void Delete(Key id);

        /// <summary>
        /// Deletes an existing entity.
        /// </summary>
        /// <param name="entityToDelete">The <see cref="Entity"/> instance to be deleted.</param>
        void Delete(Entity entityToDelete);

        /// <summary>
        /// Updates an existing persisted entity.
        /// </summary>
        /// <param name="entityToUpdate">The <see cref="Entity"/> instance to be updated.</param>
        /// <returns>
        /// The instance of the entity that was updated with the latest updated values.
        /// </returns>
        Entity Edit(Entity entityToUpdate);
    }
}
