using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Age { get; set; }
    }
}
