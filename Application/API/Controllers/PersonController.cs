using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Produces("application/json")]
    public class PersonController : Controller
    {
        private Domain.Contract.Service.IPerson _personService;
        private Domain.Contract.Repository.IPerson _personRepository;
        private Domain.Contract.Repository.IAgeGroup _ageGroupRepository;

        public PersonController(Domain.Contract.Repository.IPerson personRepository,
            Domain.Contract.Repository.IAgeGroup ageGroupRepository,
            Domain.Contract.Service.IPerson personService)
        {
            _personRepository = personRepository;
            _ageGroupRepository = ageGroupRepository;
            _personService = personService;
        }

        [HttpGet]
        public IList<Dto.Model.Person.ListResponse> List()
        {
            var personList = _personRepository.ListAll().ToList();
            var groupList = _ageGroupRepository.ListAll().ToList();

            var adapter = new Dto.Adapter.Person.ListResponse();
            return adapter.Transform(groupList, personList);
        }

        [HttpPost]
        public IList<Dto.Model.Person.ListResponse> List([FromBody]Dto.Model.Person.ListRequest payload)
        {
            var result = new List<Dto.Model.Person.ListResponse>();
            if (payload != null && ModelState.IsValid)
            {
                var personList = _personRepository.ListByName(payload.Name).ToList();
                var groupList = _ageGroupRepository.ListAll().ToList();

                var adapter = new Dto.Adapter.Person.ListResponse();
                result = adapter.Transform(groupList, personList);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return result;
        }

        [HttpPost]
        public void Create([FromBody]Dto.Model.Person.CreateRequest payload)
        {
            if (payload != null && ModelState.IsValid)
            {
                var adapter = new Dto.Adapter.Person.CreateRequest();
                var mergedResult = adapter.Transform(payload);
                _personService.Create(mergedResult);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpPost]
        public void Edit([FromBody]Dto.Model.Person.EditRequest payload)
        {
            if (payload != null && ModelState.IsValid)
            {
                var person = _personRepository.Get(payload.Id);
                if (person != null)
                {
                    var adapter = new Dto.Adapter.Person.EditRequest();
                    var mergedResult = adapter.Transform(payload, person);
                    _personService.Edit(mergedResult);
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}