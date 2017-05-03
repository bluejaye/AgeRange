using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Base;
using Domain.Entity;

namespace Data.Repository
{
    public class AgeGroup : Base.Repository<int, Domain.Entity.AgeGroup>, Domain.Contract.Repository.IAgeGroup
    {
        public AgeGroup(AgeRangerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
