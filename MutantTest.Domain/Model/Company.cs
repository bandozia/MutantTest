using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Domain.Model
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
