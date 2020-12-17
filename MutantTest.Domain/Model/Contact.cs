using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Domain.Model
{
    public class Contact
    {
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
    }
}
