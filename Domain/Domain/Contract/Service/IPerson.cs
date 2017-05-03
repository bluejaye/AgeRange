using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract.Service
{
    public interface IPerson
    {
        void Create( Entity.Person person);
        void Edit(Entity.Person person);
    }
}
