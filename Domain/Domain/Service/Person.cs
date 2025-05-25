using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using Domain.Contract;
using Domain.Contract.Events;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class Person : Contract.Service.IPerson
    {
        private IUnitOfWork _unitOfWork;
        private Contract.Repository.IPerson _personRepository;
        private Contract.Repository.IAgeGroup _ageGroupRepository;

        private readonly IDomainEventDispatcher _dispatcher;


        public Person(IUnitOfWork unitOfWork,
            Contract.Repository.IPerson personRepository,
            Contract.Repository.IAgeGroup ageGroupRepository,
            IDomainEventDispatcher dispatcher)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _ageGroupRepository = ageGroupRepository;
            _dispatcher = dispatcher;
        }

        public void Create(Entity.Person person)
        {
            if (person != null)
            {
                if (person.Age > 0)
                {
                    _personRepository.Insert(person);
                    _unitOfWork.Commit();
                }
                else
                {
                    throw new Exception($"Person's age should above 0. Age: {person.Age}");
                }
            }
        }

        public void Edit(Entity.Person person)
        {
            if (person != null)
            {
                if(person.Id <= 0)
                {
                    throw new Exception($"Invalid Id to save person. Id: {person.Id}");
                }



                if (person.Age.HasValue && (person.Age > 0))
                {
                    _personRepository.Edit(person);
                    _unitOfWork.Commit();
                }
                else
                {
                    throw new Exception($"Person's age should above 0. Age: {person.Age}");
                }
            }
        }
        public void UpdateAgeAsync(long personId, int newAge)
        {
            var person = _personRepository.Get(personId);
            person.UpdateAge(newAge);

            _personRepository.Edit(person);
            _dispatcher.DispatchAsync(person.DomainEvents).Wait();
            person.ClearDomainEvents();
            _unitOfWork.Commit();
        }

    }
}
