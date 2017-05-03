using Dto.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Adapter.Person
{
    public class EditRequest : IAdapter<Dto.Model.Person.EditRequest, Domain.Entity.Person, Domain.Entity.Person>
    {
        public Domain.Entity.Person Transform(Model.Person.EditRequest origin, Domain.Entity.Person result)
        {
            result.Id = origin.Id;
            result.FirstName = origin.FirstName;
            result.LastName = origin.LastName;
            result.Age = origin.Age;

            return result;
        }
    }
}
