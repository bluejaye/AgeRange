using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model.Person
{
    public class EditRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Age { get; set; }
    }
}
