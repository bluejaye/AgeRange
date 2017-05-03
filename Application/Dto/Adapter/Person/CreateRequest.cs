using Dto.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using Dto.Model.Person;

namespace Dto.Adapter.Person
{
    public class CreateRequest : IAdapter<Dto.Model.Person.CreateRequest, Domain.Entity.Person>
    {
        public Domain.Entity.Person Transform(Dto.Model.Person.CreateRequest origin)
        {
            return new Domain.Entity.Person()
            {
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Age = origin.Age
            };
        }
    }
}
