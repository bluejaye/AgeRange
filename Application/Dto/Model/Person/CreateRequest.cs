using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model.Person
{
    public class CreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Age { get; set; }
    }
}
