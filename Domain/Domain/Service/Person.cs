using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using Domain.Contract;

namespace Domain.Service
{
    public class Person : Contract.Service.IPerson
    {
        private IUnitOfWork _unitOfWork;
        private Contract.Repository.IPerson _personRepository;
        private Contract.Repository.IAgeGroup _ageGroupRepository;

        public Person(IUnitOfWork unitOfWork,
            Contract.Repository.IPerson personRepository,
            Contract.Repository.IAgeGroup ageGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _ageGroupRepository = ageGroupRepository;
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
    }
}
