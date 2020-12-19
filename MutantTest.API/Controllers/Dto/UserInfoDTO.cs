using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantTest.API.Controllers.Dto
{
    public class UserInfoDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public AddressDTO address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public CompanyDTO company { get; set; }

        public UserInfoDTO() { }

        public UserInfoDTO(UserInfo userInfo)
        {
            id = userInfo.SourceId;
            name = userInfo.Name;
            username = userInfo.Username;
            email = userInfo.Email;
            address = new AddressDTO(userInfo.Address);
            phone = userInfo.Contact.Phone;
            website = userInfo.Contact.Website;
            company = new CompanyDTO(userInfo.Contact.Company);
        }
        
        public UserInfo ToUserInfo() => new UserInfo
        {
            SourceId = id,
            Name = name,
            Username = username,
            Email = email,
            Address = address.ToAddress(),
            Contact = new Contact(phone, website, company.ToCompany())
        };

    }
}
