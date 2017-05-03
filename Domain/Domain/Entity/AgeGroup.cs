using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class AgeGroup
    {
        public long Id { get; set; }
        public long? MinAge { get; set; }
        public long? MaxAge { get; set; }
        public string Description { get; set; }
    }
}
