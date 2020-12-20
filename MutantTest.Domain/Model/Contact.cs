namespace MutantTest.Domain.Model
{
    public class Contact : BaseModel
    {
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
                
        public UserInfo UserInfo { get; set; }

        public Contact()
        {
        }

        public Contact(string phone, string website, Company company)
        {
            Phone = phone;
            Website = website;
            Company = company;
        }
    }
}
