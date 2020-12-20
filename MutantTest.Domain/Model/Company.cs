using System.Collections.Generic;

namespace MutantTest.Domain.Model
{
    public class Company : BaseModel
    {        
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        
        public ICollection<Contact> Contacts { get; set; }

        public Company()
        {
        }

        public Company(string name, string catchPhrase, string bs)
        {
            Name = name;
            CatchPhrase = catchPhrase;
            Bs = bs;
        }
    }
}
