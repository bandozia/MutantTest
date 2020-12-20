using MutantTest.Domain.Model;

namespace MutantTest.API.Controllers.Dto
{
    public class CompanyDTO
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }

        public CompanyDTO() {}

        public CompanyDTO(Company company)
        {
            name = company.Name;
            catchPhrase = company.CatchPhrase;
            bs = company.Bs;
        }

        public Company ToCompany() => new Company
        {
            Name = name,
            CatchPhrase = catchPhrase,
            Bs = bs
        };
    }
}
