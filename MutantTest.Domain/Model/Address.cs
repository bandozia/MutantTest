using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Domain.Model
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
                
        public UserInfo UserInfo { get; set; }

        public bool IsSuite => Suite.ToLower().Trim().Contains("suite");
        
    }
}
