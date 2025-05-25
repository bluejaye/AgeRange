using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Service
{
    public interface IPerson
    {
        void Create( Entity.Person person);
        void Edit(Entity.Person person);
        void UpdateAgeAsync(long personId, int newAge);
    }
}
