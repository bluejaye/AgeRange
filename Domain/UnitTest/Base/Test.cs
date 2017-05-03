using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Base
{
    public abstract class Test
    {
        protected Domain.Contract.IUnitOfWork _unitOfWorkMock { get; set; }
        protected bool _transactionWasCommited { get; set; }

        public Test()
        {
            var unitOfWorkSetup = new Mock<Domain.Contract.IUnitOfWork>();
            _unitOfWorkMock = unitOfWorkSetup.Object;

            unitOfWorkSetup.Setup(x => x.Commit()).Callback(() => _transactionWasCommited = true);

            this.PrepareMockBestCaseScenario();
        }
        protected virtual void PrepareMockBestCaseScenario()
        {
        }
    }
}
