using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class Person : Base.Repository<long, Domain.Entity.Person>, Domain.Contract.Repository.IPerson
    {
        public Person(AgeRangerDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Search user name by returning a list
        /// </summary>
        public IQueryable<Domain.Entity.Person> ListByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return base.ListAll();
            }
            else
            {
                var nameLowerCase = name.ToLower();
                return base.ListAll().Where(person => person.FirstName.ToLower().Contains(nameLowerCase) || person.LastName.ToLower().Contains(nameLowerCase));
            }
        }
    }
}
