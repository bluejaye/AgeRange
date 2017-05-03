using System;
using System.Linq;
using Xunit;
using Moq;

namespace UnitTest
{
    public class PersonTest : Base.Test
    {
        private Domain.Contract.Service.IPerson _personService;
        Mock<Domain.Contract.Repository.IPerson> _personRepoMock = new Mock<Domain.Contract.Repository.IPerson>();
        Mock<Domain.Contract.Repository.IAgeGroup> _ageGroupRepoMock = new Mock<Domain.Contract.Repository.IAgeGroup>();

        private Domain.Contract.Service.IPerson InitializeServiceInstance()
        {
            return new Domain.Service.Person(_unitOfWorkMock, _personRepoMock.Object, _ageGroupRepoMock.Object);
        }

        protected override void PrepareMockBestCaseScenario()
        {
            base.PrepareMockBestCaseScenario();
            _personService = InitializeServiceInstance();
        }

        [Fact]
        public void CanCreatePerson()
        {
            //Arrange
            bool insertWasCalled = false;
            var person = new Domain.Entity.Person()
            {
                FirstName = "Michael",
                LastName = "Jackson",
                Age = 55
            };
            _personRepoMock.Setup(p => p.Insert(It.IsAny<Domain.Entity.Person>())).Callback<Domain.Entity.Person>(p => insertWasCalled = true);
            //Act
            _personService.Create(person);
            //Assert
            Assert.True(insertWasCalled, "Person's insert repository was never called therefore Trip could not be created.");
            Assert.True(_transactionWasCommited, "Unit of Work transaction was not committed.");
        }

        [Fact]
        public void ShouldNotCreatePersonWithInvalidAge()
        {
            //Arrange
            bool CreatetWasCalled = false;
            var person = new Domain.Entity.Person()
            {
                Id = 33,
                FirstName = "Michael",
                LastName = "Jackson",
                Age = -1
            };
            _personRepoMock.Setup(p => p.Insert(It.IsAny<Domain.Entity.Person>())).Callback<Domain.Entity.Person>(p => CreatetWasCalled = true);
            //Act
            Assert.Throws(typeof(Exception), () => _personService.Create(person));
            //Assert
            Assert.False(CreatetWasCalled, "Person's Create repository was called but it should because age smaller than 0");
            Assert.False(_transactionWasCommited, "Unit of Work transaction was committed but it should not.");
        }

        [Fact]
        public void CanEditPerson()
        {
            //Arrange
            bool edittWasCalled = false;
            var person = new Domain.Entity.Person()
            {
                Id = 33,
                FirstName = "Michael",
                LastName = "Jackson",
                Age = 55
            };
            _personRepoMock.Setup(p => p.Edit(It.IsAny<Domain.Entity.Person>())).Callback<Domain.Entity.Person>(p => edittWasCalled = true);
            //Act
            _personService.Edit(person);
            //Assert
            Assert.True(edittWasCalled, "Person's edit repository was never called therefore Trip could not be created.");
            Assert.True(_transactionWasCommited, "Unit of Work transaction was not committed.");
        }

        [Fact]
        public void ShouldNotEditPersonWithInvalidAge()
        {
            //Arrange
            bool edittWasCalled = false;
            var person = new Domain.Entity.Person()
            {
                Id = 33,
                FirstName = "Michael",
                LastName = "Jackson",
                Age = -1
            };
            _personRepoMock.Setup(p => p.Edit(It.IsAny<Domain.Entity.Person>())).Callback<Domain.Entity.Person>(p => edittWasCalled = true);
            //Act
            Assert.Throws(typeof(Exception), () => _personService.Edit(person));
            //Assert
            Assert.False(edittWasCalled, "Person's edit repository was called but it should because age smaller than 0");
            Assert.False(_transactionWasCommited, "Unit of Work transaction was committed but it should not.");
        }

        [Fact]
        public void ShouldNotEditPersonWithoutId()
        {
            //Arrange
            bool edittWasCalled = false;
            var person = new Domain.Entity.Person()
            {
                FirstName = "Michael",
                LastName = "Jackson",
                Age = 55
            };
            _personRepoMock.Setup(p => p.Edit(It.IsAny<Domain.Entity.Person>())).Callback<Domain.Entity.Person>(p => edittWasCalled = true);
            //Act
            Assert.Throws(typeof(Exception), () => _personService.Edit(person));
            //Assert
            Assert.False(edittWasCalled, "Person's edit repository was called but it should because age smaller than 0");
            Assert.False(_transactionWasCommited, "Unit of Work transaction was not committed but it should not.");
        }
    }
}
