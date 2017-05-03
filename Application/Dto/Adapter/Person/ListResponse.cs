using Dto.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dto.Adapter.Person
{
    public class ListResponse : IAdapter<List<Domain.Entity.AgeGroup>, List<Domain.Entity.Person>, List<Dto.Model.Person.ListResponse>>
    {
        public List<Model.Person.ListResponse> Transform(List<Domain.Entity.AgeGroup> origin, List<Domain.Entity.Person> origin2)
        {
            var result = (from person in origin2
                          select new Model.Person.ListResponse()
                          {
                              Id = person.Id,
                              FirstName = person.FirstName,
                              LastName = person.LastName,
                              Age = person.Age
                          }).ToList();

            //fill in age group for each person
            foreach (var person in result)
            {
                if (person.Age.HasValue)
                {
                    var group = origin.FirstOrDefault(g =>
                    (g.MinAge.HasValue && g.MaxAge.HasValue ? (person.Age >= g.MinAge && person.Age < g.MaxAge) : false) ||
                    (g.MinAge.HasValue && !g.MaxAge.HasValue ? person.Age >= g.MinAge : false) ||
                    (g.MaxAge.HasValue && g.MinAge.HasValue ? person.Age < g.MaxAge : false));
                    person.AgeGroup = group != null ? group.Description : "Ungrouped";
                }
            }

            return result;
        }
    }
}
