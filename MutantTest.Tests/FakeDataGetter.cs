using MutantTest.API.Controllers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Tests
{
    internal static class FakeDataGetter
    {
        internal static IEnumerable<UserInfoDTO> GetFakeUserData(int c = 5, string overrideSuite = null)
        {
            var rand = new Random();            
            var userList = new List<UserInfoDTO>();
            for (int i = 1; i < c+2; i++)
            {
                userList.Add(new UserInfoDTO
                {
                    id = rand.Next(1, 5000),
                    name = $"Test user {i}",
                    username = $"testeuser_{i}",
                    email = $"testuser{i}@email.com",
                    phone = $"1235467{i}",
                    website = $"www.testeuser{i}.com",
                    address = new AddressDTO
                    {
                        city = $"Test City {i}",
                        street = $"Street no {i}",
                        zipcode = $"1234778{i}",
                        geo = new GeoDTO { lat = i * 1000, lng = i * 1500},
                        suite = overrideSuite == null ? (i % 2 == 0 ? $"Apt. {i}" : $"Suite {i}") : overrideSuite
                    },
                    company = new CompanyDTO
                    {
                        name = $"Company {i}",
                        catchPhrase = $"The {i} Phrase",
                        bs = $"business {i}"
                    }
                });
            }

            return userList;
        }

        
        
    }
}
