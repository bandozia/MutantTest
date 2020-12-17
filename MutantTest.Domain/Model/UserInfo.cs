using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Domain.Model
{
    public class UserInfo : BaseModel
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        
        public Address Address { get; set; }
        public Contact Contact { get; set; }
    }
}
