using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    public class AgeGroupController : Controller
    {
        private Domain.Contract.Service.IPerson _personService;
        private Domain.Contract.Repository.IPerson _personRepository;
        private Domain.Contract.Repository.IAgeGroup _ageGroupRepository;

        public AgeGroupController(Domain.Contract.Repository.IPerson personRepository,
            Domain.Contract.Repository.IAgeGroup ageGroupRepository,
            Domain.Contract.Service.IPerson personService)
        {
            _personRepository = personRepository;
            _ageGroupRepository = ageGroupRepository;
            _personService = personService;
        }

        [HttpGet]
        public IList<Domain.Entity.AgeGroup> List()
        {
            return _ageGroupRepository.ListAll().ToList();
        }

    }
}