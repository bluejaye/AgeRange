using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contract
{
    /// <summary>
    /// Unit of work interface definition.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Persists all changes to database.
        /// </summary>
        void Commit();
    }
}
