using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Domain.Model
{
    public class Geo : BaseModel
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}
