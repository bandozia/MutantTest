using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantTest.API.Controllers.Form
{
    public class UserForm
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }

        public UserInfo ToUserInfo()
        {
            return new UserInfo 
            { 
                SourceId = id,
                Name = name,
                Username = username,
                Email = email,
                Address = address,
                Contact = new Contact(phone, website, company)
            };
        }
    }
}
