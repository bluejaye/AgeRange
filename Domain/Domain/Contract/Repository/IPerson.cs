using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Contract.Repository
{
    public interface IPerson : IRepository<long, Entity.Person>
    {
        /// <summary>
        /// Search user name by returning a list
        /// </summary>
        IQueryable<Domain.Entity.Person> ListByName(string name);
    }
}
